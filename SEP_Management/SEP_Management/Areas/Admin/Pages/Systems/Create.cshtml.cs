using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SEP_Management.Models;

namespace SEP_Management.Areas.Admin.Pages.Systems
{
    public class CreateModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public CreateModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SystemSetting SystemSetting { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.SystemSettings == null || SystemSetting == null)
            {
                return Page();
            }

            _context.SystemSettings.Add(SystemSetting);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
