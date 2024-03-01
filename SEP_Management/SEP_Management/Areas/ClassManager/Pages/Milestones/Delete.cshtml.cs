using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Models;

namespace SEP_Management.Areas.ClassManager.Pages.Milestones
{
    public class DeleteModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public DeleteModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Milestone Milestone { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Milestones == null)
            {
                return NotFound();
            }

            var milestone = await _context.Milestones.FirstOrDefaultAsync(m => m.MilestoneId == id);

            if (milestone == null)
            {
                return NotFound();
            }
            else 
            {
                Milestone = milestone;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Milestones == null)
            {
                return NotFound();
            }
            var milestone = await _context.Milestones.FindAsync(id);

            if (milestone != null)
            {
                Milestone = milestone;
                _context.Milestones.Remove(Milestone);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
