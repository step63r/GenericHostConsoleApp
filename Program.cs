using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using GenericHostConsoleApp.Services;

internal class Program
{
    /// <summary>
    /// プログラムエントリポイント
    /// </summary>
    /// <param name="args">コマンドライン引数</param>
    private static async Task Main(string[] args)
    {
        await Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(Path.GetDirectoryName(Environment.ProcessPath));
                config.AddJsonFile("appsettings2.json", optional: true);
                config.AddJsonFile("nlog.json", optional: true);
            })
            .ConfigureLogging((context, logging) => 
            {
                logging.ClearProviders();
                logging.AddNLog(new NLogLoggingConfiguration(context.Configuration.GetSection("NLog")));
            })
            .ConfigureServices((context, services) =>
            {
                services.AddHostedService<ExampleHostedService>();
                services.AddHostedService<ExampleBackgroundHostedService>();
            })
            .Build()
            .RunAsync();
    }
}