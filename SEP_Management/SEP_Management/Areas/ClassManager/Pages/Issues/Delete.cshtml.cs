using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Models;

namespace SEP_Management.Areas.ClassManager.Pages.Issues
{
    public class DeleteModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public DeleteModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Issue Issue { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Issues == null)
            {
                return NotFound();
            }

            var issue = await _context.Issues.FirstOrDefaultAsync(m => m.IssueId == id);

            if (issue == null)
            {
                return NotFound();
            }
            else 
            {
                Issue = issue;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Issues == null)
            {
                return NotFound();
            }
            var issue = await _context.Issues.FindAsync(id);

            if (issue != null)
            {
                Issue = issue;
                _context.Issues.Remove(Issue);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
