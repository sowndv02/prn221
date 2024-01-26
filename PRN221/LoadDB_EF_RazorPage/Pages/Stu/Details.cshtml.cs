﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LoadDB_EF_RazorPage.Models;

namespace LoadDB_EF_RazorPage.Pages.Stu
{
    public class DetailsModel : PageModel
    {
        private readonly LoadDB_EF_RazorPage.Models.PRN211_1Context _context;

        public DetailsModel(LoadDB_EF_RazorPage.Models.PRN211_1Context context)
        {
            _context = context;
        }

      public Student Student { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            else 
            {
                Student = student;
            }
            return Page();
        }
    }
}
