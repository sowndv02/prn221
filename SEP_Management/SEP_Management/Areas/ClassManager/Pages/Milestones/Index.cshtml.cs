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
    public class IndexModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public IndexModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        public IList<Milestone> Milestone { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Milestones != null)
            {
                Milestone = await _context.Milestones
                .Include(m => m.Class)
                .Include(m => m.Project).ToListAsync();
            }
        }
    }
}
