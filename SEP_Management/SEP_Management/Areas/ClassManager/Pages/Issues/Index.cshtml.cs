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
    public class IndexModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public IndexModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        public IList<Issue> Issue { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Issues != null)
            {
                Issue = await _context.Issues
                .Include(i => i.Milestone)
                .Include(i => i.Project)
                .Include(i => i.Type).ToListAsync();
            }
        }
    }
}
