using Microsoft.EntityFrameworkCore;

namespace EF_With_SignalR_MVC.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
        }
        public virtual DbSet<Product> Products { get; set; }
    }
}
