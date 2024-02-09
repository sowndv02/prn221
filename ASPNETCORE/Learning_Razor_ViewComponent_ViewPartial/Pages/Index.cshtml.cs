using Learning_Razor_ViewComponent_ViewPartial.Pages.Shared.Components.MessagePage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Learning_Razor_ViewComponent_ViewPartial.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            return Partial("_Message"); // Trả về PartialViewResult trả về msg

            //return ViewComponent("ProductBox"); // Trả về 1 component
        }

        public IActionResult OnPost()
        {
            var username = this.Request.Form["username"];
            var message = new MessagePage.Message();
            message.title = "Alert";
            message.htmlcontent = "Thanks";
            message.secondwait = 3;
            message.urlredirect = Url.Page("Privacy");
            return ViewComponent("MessagePage", message);
        }
    }
}