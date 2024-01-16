using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo_RazorPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


        public string Name {  get; set; }   
        public void OnGet()
        {
            /*
             MVC: ViewBag, ViewData, Model, Tempdata
             Razor kh co viewbag
             */
            Name = "Tran Van B";
        }
    }
}