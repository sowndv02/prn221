namespace ExchangeRateService_DemoWorkerService
{
    public class CurrencyExchange
    {
        public string Base { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }  
    }
}
