using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Models;

namespace SEP_Management.Areas.ClassManager.Pages.SubjectSettings
{
    public class DeleteModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public DeleteModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
      public SubjectSetting SubjectSetting { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SubjectSettings == null)
            {
                return NotFound();
            }

            var subjectsetting = await _context.SubjectSettings.FirstOrDefaultAsync(m => m.SettingId == id);

            if (subjectsetting == null)
            {
                return NotFound();
            }
            else 
            {
                SubjectSetting = subjectsetting;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SubjectSettings == null)
            {
                return NotFound();
            }
            var subjectsetting = await _context.SubjectSettings.FindAsync(id);

            if (subjectsetting != null)
            {
                SubjectSetting = subjectsetting;
                _context.SubjectSettings.Remove(SubjectSetting);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
