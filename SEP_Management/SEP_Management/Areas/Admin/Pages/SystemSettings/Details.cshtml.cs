using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Models;

namespace SEP_Management.Areas.Admin.Pages.Roles
{
    public class DetailsModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public DetailsModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

      public Role Role { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var role = await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);
            if (role == null)
            {
                return NotFound();
            }
            else 
            {
                Role = role;
            }
            return Page();
        }
    }
}
