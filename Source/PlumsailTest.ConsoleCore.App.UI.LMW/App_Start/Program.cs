// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using PlumsailTest.ConsoleCore.App.UI.LMW.Controllers;
using PlumsailTest.ConsoleCore.App.UI.LMW.Models;
using Serilog;
using Serilog.Formatting.Compact;

namespace PlumsailTest.ConsoleCore.App.UI.LMW.App_Start; // Note: actual namespace depends on the project name.

internal class Program
{
    private static async Task Main(string[] args)
    {
        try
        {
            ConfigureLog();
            Log.Logger.Information("Start");
            Console.WriteLine("Start");

            var serviceProvider = DIConfigurator.Register();
            var filesPaths = ConfigurePaths(args);
            var controller = serviceProvider.GetService<MainController>();

            await controller.StartAsync(filesPaths).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception occurred. See logs");
            Log.Logger.Error(ex, "Exception occurred");
        }
        finally
        {
            Log.Logger.Information("End. Press any key to exit");
            Console.WriteLine("End. Press any key to exit");
            Console.ReadKey();
        }
    }

    private static void ConfigureLog() => Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File(new CompactJsonFormatter(), $"logs\\{DateTime.UtcNow.ToLongDateString()}.txt")/*.WriteTo.Console()*/.CreateLogger();

    private static FilesPathsModel ConfigurePaths(IReadOnlyList<string> args)
    {
        const bool usePathsFromConsoleArguments = true;

        if (usePathsFromConsoleArguments)
        {
            if (args.Count == 0) Console.WriteLine("HELP: Start Console application with parameters \"templateFilePath\", \"dataFilePath\", \"outputFilePath\"");
            if (args.Count != 3) throw new ArgumentOutOfRangeException("Start Console application with parameters: \"templateFilePath\", \"dataFilePath\", \"outputFilePath\"");

            return new FilesPathsModel(args, Log.Logger);
        }

        return new FilesPathsModel(Log.Logger);
    }
}