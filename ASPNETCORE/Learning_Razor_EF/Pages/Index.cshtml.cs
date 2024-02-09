using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Learning_Razor_EF.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public const int ITEMS_PER_PAGE = 10;

        public int countPages {  get; set; }
        [BindProperty(SupportsGet = true,Name="page")]
        public int currentPages { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            int totalAricle = 0; // get total article
            countPages = (int)Math.Ceiling((double)totalAricle / ITEMS_PER_PAGE);
            if(currentPages < 1 ) currentPages = 1;
            if(currentPages >countPages ) currentPages = countPages;
            // get data using skip(bo qua bn) and take(lay bn ptu)
        }
    }
}