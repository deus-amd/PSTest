using Newtonsoft.Json;
using PlumsailTest.Library.ALMW.Models;
using System.Text;
using System.Text.RegularExpressions;

namespace PlumsailTest.Library.ALMW;

public sealed class Templater : ITemplater
{
    /// <exception cref="NullReferenceException">templateModel must not be null</exception>
    public string CreateHtml(string template, string jsonData)
    {
        var templateModel = GetTemplateModel(jsonData);
        var templateLines = GetTemplateLines(template);

        if (templateModel == null) throw new NullReferenceException("templateModel must not be null");

        return Generate(templateModel, templateLines);
    }

    private static string FindTemplate(IReadOnlyList<string> templateLines)
    {
        var sb = new StringBuilder();
        var startSearchTemplateLine = false;

        for (var i = 1; i < templateLines.Count - 1; i++)
        {
            var templateLine = templateLines[i];

            if (!startSearchTemplateLine && templateLine.Contains(TemplateKeyWords.TemplateStartKey))
            {
                startSearchTemplateLine = true;
            }
            else if (startSearchTemplateLine && templateLine.Contains(TemplateKeyWords.TemplateEndKey))
            {
                startSearchTemplateLine = false;
            }
            else if (startSearchTemplateLine) sb.AppendLine(templateLine);
        }

        return sb.ToString().TrimEnd();
    }

    private static string Generate(TemplateModel templateModel, IReadOnlyList<string> templateLines)
    {
        var sb = new StringBuilder();

        sb.AppendLine(templateLines[0]);

        var templateItem = FindTemplate(templateLines);

        if (templateModel.Products == null) throw new NullReferenceException("templateModel.Products must not be null");

        foreach (var product in templateModel.Products) sb.AppendLine(TemplateMapper.Map(templateItem, product)); // Parallel.ForEach = change sort order

        sb.AppendLine(templateLines[^1]);

        return sb.ToString();
    }

    private static TemplateModel? GetTemplateModel(string jsonData) => JsonConvert.DeserializeObject<TemplateModel>(jsonData); // (jsonObject as dynamic).products[0]

    private static string[] GetTemplateLines(string template) => Regex.Split(template, "\r\n|\r|\n"); // template.Split('\r', '\n');
}