using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GenericHostConsoleApp.Services
{
    /// <summary>
    /// サービスのクラス
    /// </summary>
    /// <param name="configuration">IConfiguration</param>
    /// <param name="logger">ILogger</param>
    public sealed class ExampleHostedService(IConfiguration configuration, ILogger<ExampleHostedService> logger) : IHostedService
    {
        /// <summary>
        /// IConfiguration
        /// </summary>
        private readonly IConfiguration _configuration = configuration;

        /// <summary>
        /// ILogger
        /// </summary>
        private readonly ILogger<ExampleHostedService> _logger = logger;

        /// <summary>
        /// サービスが開始するときにトリガーされるメソッド
        /// </summary>
        /// <param name="cancellationToken">キャンセルトークン</param>
        /// <returns>実行結果</returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("StartAsync has been called.");

            IConfigurationSection parameters = _configuration.GetSection("Parameters");
            Console.WriteLine(parameters.GetValue<string>("param1"));
            Console.WriteLine(parameters.GetValue<string>("param2"));
            Console.WriteLine(parameters.GetValue<string>("param3"));
            return Task.CompletedTask;
        }

        /// <summary>
        /// サービスが終了するときにトリガーされるメソッド
        /// </summary>
        /// <param name="cancellationToken">キャンセルトークン</param>
        /// <returns>実行結果</returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("StopAsync has been called.");
            return Task.CompletedTask;
        }
    }
}