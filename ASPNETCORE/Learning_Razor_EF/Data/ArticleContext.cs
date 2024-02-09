using Learning_Razor_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning_Razor_EF.Data
{
    public class ArticleContext : DbContext
    {
        public ArticleContext(DbContextOptions<ArticleContext> options) : base(options)
        {
            // Phương thức khởi tạo này chứa options để kết nối đến MS SQL Server
            // Thực hiện điều này khi Inject trong dịch vụ hệ thống
        }
        public DbSet<Article> Article { set; get; }
    }
}
