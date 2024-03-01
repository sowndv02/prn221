using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Models;

namespace SEP_Management.Areas.SubjectManager.Pages.SubjectSettings
{
    public class IndexModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public IndexModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        public IList<SubjectSetting> SubjectSetting { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SubjectSettings != null)
            {
                SubjectSetting = await _context.SubjectSettings
                .Include(s => s.Subject).ToListAsync();
            }
        }
    }
}
