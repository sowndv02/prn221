using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Learning_Razor_Identity_Login.Pages.Articles
{
    [Authorize] // Xác thực trc khi vào index
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
