using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Models;

namespace SEP_Management.Areas.ClassManager.Pages.Classes
{
    public class DetailsModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public DetailsModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        public Class Class { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var classObject = await _context.Classes.FirstOrDefaultAsync(m => m.ClassId == id);
            if (classObject == null)
            {
                return NotFound();
            }
            else
            {
                Class = classObject;
            }
            return Page();
        }
    }
}
