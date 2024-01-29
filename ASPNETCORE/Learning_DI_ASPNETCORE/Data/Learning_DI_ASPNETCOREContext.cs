using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Learning_DI_ASPNETCORE.Services;

namespace Learning_DI_ASPNETCORE.Data
{
    public class Learning_DI_ASPNETCOREContext : DbContext
    {
        public Learning_DI_ASPNETCOREContext (DbContextOptions<Learning_DI_ASPNETCOREContext> options)
            : base(options)
        {
        }

        public DbSet<Learning_DI_ASPNETCORE.Services.Product> Product { get; set; } = default!;
    }
}
