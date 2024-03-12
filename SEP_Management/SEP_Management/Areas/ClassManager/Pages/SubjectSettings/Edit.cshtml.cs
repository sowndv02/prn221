using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Models;

namespace SEP_Management.Areas.ClassManager.Pages.SubjectSettings
{
    public class EditModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public EditModel(SEP_Management.Models.SEP_ManagementContext context)
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

            var subjectsetting =  await _context.SubjectSettings.FirstOrDefaultAsync(m => m.SettingId == id);
            if (subjectsetting == null)
            {
                return NotFound();
            }
            SubjectSetting = subjectsetting;
           ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SubjectSetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectSettingExists(SubjectSetting.SettingId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SubjectSettingExists(int id)
        {
          return (_context.SubjectSettings?.Any(e => e.SettingId == id)).GetValueOrDefault();
        }
    }
}
