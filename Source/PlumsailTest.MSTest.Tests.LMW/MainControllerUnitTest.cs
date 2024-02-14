using Microsoft.Extensions.DependencyInjection;
using PlumsailTest.ConsoleCore.App.UI.LMW.App_Start;
using PlumsailTest.ConsoleCore.App.UI.LMW.Controllers;
using PlumsailTest.ConsoleCore.App.UI.LMW.Models;
using Serilog;
using Serilog.Formatting.Compact;

namespace PlumsailTest.MSTest.Tests.LMW;

[TestClass]
public class MainControllerUnitTest
{
    /// <exception cref="InvalidOperationException">When the logger is already created</exception>
    /// <exception cref="ArgumentNullException">When <paramref name="sinkConfiguration" /> is <code>null</code></exception>
    /// <exception cref="IOException">Condition.</exception>
    /// <exception cref="NotSupportedException">Condition.</exception>
    /// <exception cref="PathTooLongException">When <paramref name="path" /> is too long</exception>
    /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission to access the <paramref name="path" /></exception>
    /// <exception cref="ArgumentException">Invalid <paramref name="path" /></exception>
    [TestMethod]
    public void StartAsyncTestMethod()
    {
        using var logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File(new CompactJsonFormatter(), $"logs\\{DateTime.UtcNow.ToLongDateString()}.txt")/*.WriteTo.Console()*/.CreateLogger();
        Log.Logger = logger;

        try
        {
            Log.Logger.Information("Start");
            Console.WriteLine("Start");

            var serviceProvider = DIConfigurator.Register();
            var filesPaths = new FilesPathsModel(Log.Logger);
            var controller = serviceProvider.GetService<MainController>();

            controller.StartAsync(filesPaths).GetAwaiter();
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
            // Console.ReadKey();
        }
    }
}