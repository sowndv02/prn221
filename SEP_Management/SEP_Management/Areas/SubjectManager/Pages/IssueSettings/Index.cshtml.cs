using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Models;

namespace SEP_Management.Areas.SubjectManager.Pages.IssueSettings
{
    public class IndexModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public IndexModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        public IList<IssueSetting> IssueSetting { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.IssueSettings != null)
            {
                IssueSetting = await _context.IssueSettings
                .Include(i => i.Class)
                .Include(i => i.Project)
                .Include(i => i.Subject).ToListAsync();
            }
        }
    }
}
