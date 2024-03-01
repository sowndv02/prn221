using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Models;

namespace SEP_Management.Areas.SubjectManager.Pages.IssueSettings
{
    public class EditModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public EditModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IssueSetting IssueSetting { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.IssueSettings == null)
            {
                return NotFound();
            }

            var issuesetting =  await _context.IssueSettings.FirstOrDefaultAsync(m => m.SettingId == id);
            if (issuesetting == null)
            {
                return NotFound();
            }
            IssueSetting = issuesetting;
           ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassId");
           ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId");
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

            _context.Attach(IssueSetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssueSettingExists(IssueSetting.SettingId))
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

        private bool IssueSettingExists(int id)
        {
          return (_context.IssueSettings?.Any(e => e.SettingId == id)).GetValueOrDefault();
        }
    }
}
