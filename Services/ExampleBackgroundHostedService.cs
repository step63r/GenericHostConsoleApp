using Microsoft.Extensions.Hosting;

namespace GenericHostConsoleApp.Services
{
    /// <summary>
    /// バックグラウンドサービスのクラス
    /// </summary>
    /// <param name="applicationLifetime">IHostApplicationLifetime</param>
    public sealed class ExampleBackgroundHostedService(IHostApplicationLifetime applicationLifetime) : BackgroundService
    {
        /// <summary>
        /// IHostApplicationLifetime
        /// </summary>
        private readonly IHostApplicationLifetime _applicationLifetime = applicationLifetime;

        /// <summary>
        /// サービスが開始するときにトリガーされる
        /// </summary>
        /// <param name="stoppingToken">キャンセルトークン</param>
        /// <returns>実行結果</returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine(i);
                    if (i == 10)
                    {
                        _applicationLifetime.StopApplication();
                    }
                    await Task.Delay(1000, stoppingToken);
                }
            }
        }
    }
}