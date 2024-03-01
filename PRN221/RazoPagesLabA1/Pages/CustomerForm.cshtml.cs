using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazoPagesLabA1.Models;

namespace RazoPagesLabA1.Pages
{
    public class CustomerFormModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public Customer customerInfo { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = "Information is OK";
                ModelState.Clear();
            }
            else
            {
                Message = "Error input data.";
            }
        }
    }
}
