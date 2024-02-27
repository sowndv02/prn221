using System.Net.Http.Json;
using System.Text.Json;

namespace DemoWorkerService03
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        const int ThreadDelay = 5000;
        HttpClient _httpClient;
        string BaseURL = @"http://localhost:5064/ExchangeRate/GetLatestRates";
        JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public Worker(ILogger<Worker> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            _httpClient = httpClient.CreateClient();   
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                try
                {
                    //Get data from API
                    var exchangeResult = await _httpClient.GetFromJsonAsync<CurrencyExchange>(BaseURL, serializerOptions, stoppingToken);
                    _logger.LogInformation($"Base: {exchangeResult.Base}, Date:{exchangeResult.Date}");
                    foreach(var item in exchangeResult.Rates)
                    {
                        _logger.LogInformation($"{item.Key} - {item.Value}");
                    }
                    _logger.LogInformation(new string('*', 30));
                }
                catch(HttpRequestException ex)
                {
                    _logger.LogCritical($"{nameof(HttpRequestException)}: {ex.Message}");
                }
                await Task.Delay(ThreadDelay, stoppingToken);
            }
        }
    }
}