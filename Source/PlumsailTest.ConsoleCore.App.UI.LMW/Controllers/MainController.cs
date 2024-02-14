using PlumsailTest.ConsoleCore.App.UI.LMW.Models;
using PlumsailTest.Library.ALMW;
using PlumsailTest.Library.ALMW.FilesIO;
using Serilog;

namespace PlumsailTest.ConsoleCore.App.UI.LMW.Controllers;

public sealed class MainController
{
    private readonly IFileReader _fileReader;
    private readonly IFileWriter _fileWriter;
    private readonly ILogger _logger;
    private readonly ITemplater _templater;

    public MainController(IFileReader fileReader, IFileWriter fileWriter, ILogger logger, ITemplater templater)
    {
        _fileReader = fileReader;
        _fileWriter = fileWriter;
        _logger = logger;
        _templater = templater;
    }

    public async Task StartAsync(FilesPathsModel filesPathsModel)
    {
        var template = await ReadTemplateAsync(filesPathsModel.TemplateFilePath).ConfigureAwait(false);
        var jsonData = await ReadJsonDataAsync(filesPathsModel.DataFilePath).ConfigureAwait(false);

        await WriteOutputDataAsync(template, jsonData, filesPathsModel.OutputFilePath).ConfigureAwait(false);
    }

    private Task<string> ReadTemplateAsync(string templateFilePath)
    {
        _logger.Information(nameof(ReadTemplateAsync));
        // _log.Information(template);

        // return File.ReadAllText(templateFilePath, Encoding.UTF8);
        return _fileReader.ReadAsync(templateFilePath);
    }

    private Task<string> ReadJsonDataAsync(string dataFilePath)
    {
        _logger.Information(nameof(ReadJsonDataAsync));
        // _log.Information(jsonData);

        // return File.ReadAllText(dataFilePath, Encoding.UTF8);
        return _fileReader.ReadAsync(dataFilePath);
    }

    private Task WriteOutputDataAsync(string template, string jsonData, string outputFilePath)
    {
        _logger.Information(nameof(WriteOutputDataAsync));

        var outputData = _templater.CreateHtml(template, jsonData);

        _logger.Information(outputData);

        // File.WriteAllText(outputFilePath, outputData, Encoding.UTF8);
        return _fileWriter.WriteAsync(outputFilePath, outputData);
    }
}