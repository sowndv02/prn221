using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Models;

namespace SEP_Management.Areas.ClassManager.Pages.Classes
{
    public class IndexModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public IndexModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        public IList<Class> Class { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Classes != null)
            {
                Class = await _context.Classes.ToListAsync();
            }
        }
    }
}
