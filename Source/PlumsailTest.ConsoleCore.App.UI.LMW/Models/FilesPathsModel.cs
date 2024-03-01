using Serilog;

namespace PlumsailTest.ConsoleCore.App.UI.LMW.Models;

public sealed class FilesPathsModel
{
    public string DataFilePath { get; set; }

    public string OutputFilePath { get; set; }

    public string TemplateFilePath { get; set; }

    /// <exception cref="ArgumentException">.NET Framework and .NET Core versions older than 2.1: <paramref name="path1" /> or <paramref name="path2" /> contains one or more of the invalid characters defined in <see cref="M:System.IO.Path.GetInvalidPathChars" />.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="path1" /> or <paramref name="path2" /> is <see langword="null" />.</exception>
    /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
    /// <exception cref="NotSupportedException">The operating system is Windows CE, which does not have current directory functionality.
    ///  This method is available in the .NET Compact Framework, but is not currently supported.</exception>
    public FilesPathsModel(ILogger logger)
    {
        // const string dataFolderPath = @"C:\$cache\projects.ef.prototypes\PlumsailTest\Data\";
        var dataFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");

        DataFilePath = Path.Combine(dataFolderPath, "data.json");
        OutputFilePath = Path.Combine(dataFolderPath, "output.html");
        TemplateFilePath = Path.Combine(dataFolderPath, "template.html");

        Log(logger);
    }

    public FilesPathsModel(IReadOnlyList<string> args, ILogger logger)
    {
        DataFilePath = args[1];
        OutputFilePath = args[2];
        TemplateFilePath = args[0];

        Log(logger);
    }

    private void Log(ILogger logger)
    {
        logger.Information($"DataFilePath: {DataFilePath}");
        logger.Information($"OutputFilePath: {OutputFilePath}");
        logger.Information($"TemplateFilePath: {TemplateFilePath}");
    }
}