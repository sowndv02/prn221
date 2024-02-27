using Microsoft.AspNetCore.Mvc;

namespace ExchangeRateService_DemoWorkerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeRateController : ControllerBase
    {
        [HttpGet]
        [Route("GetLatesRates")]
        public CurrencyExchange GetLatesRates()
        {
            var rates = new Dictionary<string, decimal>();
            rates.Add("CAD", 1.260046m);
            rates.Add("CHF", 0.933058m);
            rates.Add("EUR", 0.806942m);
            rates.Add("GBP", 0.719154m);

            CurrencyExchange currencyExchange = new CurrencyExchange
            {
                Base = "USD",
                Date = DateTime.Now,
                Rates = rates
            };
            return currencyExchange;
        }
    }
}
