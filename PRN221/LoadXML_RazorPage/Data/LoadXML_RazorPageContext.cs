using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoadXML_RazorPage.Models;

namespace LoadXML_RazorPage.Data
{
    public class LoadXML_RazorPageContext : DbContext
    {
        public LoadXML_RazorPageContext (DbContextOptions<LoadXML_RazorPageContext> options)
            : base(options)
        {
        }

        public DbSet<LoadXML_RazorPage.Models.Person> Person { get; set; } = default!;
    }
}
