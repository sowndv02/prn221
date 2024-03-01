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
    public class DetailsModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public DetailsModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

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
    }
}
