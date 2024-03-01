﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EntityFramework_With_SignalR.Models;
using EntityFramework_With_SignalR.SignalRConfig;
using Microsoft.AspNetCore.SignalR;

namespace EntityFramework_With_SignalR.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly EntityFramework_With_SignalR.Models.PRN211_1Context _context;
        private readonly IHubContext<SignalrServer> _signalRHub;

        public CreateModel(EntityFramework_With_SignalR.Models.PRN211_1Context context, IHubContext<SignalrServer> signalRHub)
        {
            _context = context;
            _signalRHub = signalRHub;
        }

        public IActionResult OnGet()
        {
        ViewData["DepartId"] = new SelectList(_context.Departments, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Students == null || Student == null)
            {
                return Page();
            }

            _context.Students.Add(Student);
            await _context.SaveChangesAsync();

            // Send client
            await _signalRHub.Clients.All.SendAsync("LoadAll");

            return RedirectToPage("./Index");
        }
    }
}
