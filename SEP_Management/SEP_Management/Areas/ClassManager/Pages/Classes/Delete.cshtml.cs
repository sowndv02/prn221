using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Models;

namespace SEP_Management.Areas.ClassManager.Pages.Classes
{
    public class DeleteModel : PageModel
    {
        private readonly SEP_ManagementContext _context;

        public DeleteModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }
            var classObject = await _context.Classes.FindAsync(id);

            if (classObject != null)
            {
                Class = classObject;
                _context.Classes.Remove(Class);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
