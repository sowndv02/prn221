using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Models;

namespace SEP_Management.Areas.Admin.Pages.Systems
{
    public class DetailsModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public DetailsModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

      public SystemSetting SystemSetting { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SystemSettings == null)
            {
                return NotFound();
            }

            var systemsetting = await _context.SystemSettings.FirstOrDefaultAsync(m => m.SettingId == id);
            if (systemsetting == null)
            {
                return NotFound();
            }
            else 
            {
                SystemSetting = systemsetting;
            }
            return Page();
        }
    }
}
