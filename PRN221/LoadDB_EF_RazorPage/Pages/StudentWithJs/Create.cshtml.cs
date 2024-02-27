using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LoadDB_EF_RazorPage.Models;
using Microsoft.EntityFrameworkCore;

namespace LoadDB_EF_RazorPage.Pages.StudentWithJs
{
    public class CreateModel : PageModel
    {
        private readonly LoadDB_EF_RazorPage.Models.PRN211_1Context _context;

        public CreateModel(LoadDB_EF_RazorPage.Models.PRN211_1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Depart"] = _context.Departments.ToList();
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Students == null || Student == null)
            {
                return Page();
            }
            _context.Students.Add(Student);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
