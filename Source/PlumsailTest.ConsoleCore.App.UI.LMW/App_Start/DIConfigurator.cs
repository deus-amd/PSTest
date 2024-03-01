using Microsoft.Extensions.DependencyInjection;
using PlumsailTest.ConsoleCore.App.UI.LMW.Controllers;
using PlumsailTest.Library.ALMW;
using PlumsailTest.Library.ALMW.FilesIO;
using Serilog;

namespace PlumsailTest.ConsoleCore.App.UI.LMW.App_Start;

public class DIConfigurator
{
    /// <exception cref="ArgumentNullException">When <paramref name="value" /> is <code>null</code></exception>
    public static ServiceProvider Register()
    {
        // AddSingleton - only singleton instance
        // AddScoped - new instance per request
        // AddTransient - new instance every call

        return new ServiceCollection()
            .AddSingleton(Log.Logger)
            .AddSingleton<IFileReader, FileReader>()
            .AddSingleton<IFileWriter, FileWriter>()
            .AddSingleton<ITemplater, Templater>()
            .AddSingleton<MainController>()
            .BuildServiceProvider();
    }
}