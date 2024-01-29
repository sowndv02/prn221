using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_EF.Models
{
    public class WebContext : DbContext
    {
        public DbSet<Article> articles { set; get; }        // bảng article
        public DbSet<Tag> tags { set; get; }                // bảng tag
        public DbSet<ArticleTag> articleTags { set; get; }
        // chuỗi kết nối với tên db sẽ làm  việc đặt là webdb
        private const string connectionString = "server=DESKTOP-V87NI7H\\SQLEXPRESS;database=shop01;user=sa;password=sa123456";
        //private const string connectionString = "server=COOKIE\\SQLEXPRESS;database=shop01;user=sa;password=123456";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseLoggerFactory(GetLoggerFactory());       // bật logger
        }

        private ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
                    builder.AddConsole()
                           .AddFilter(DbLoggerCategory.Database.Command.Name,
                                    LogLevel.Information));
            return serviceCollection.BuildServiceProvider()
                    .GetService<ILoggerFactory>();
        }


        // Tạo mqh N-N thì chỉ fluent API mới tạo đc
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleTag>(entity => {
                // Tạo Index Unique trên 2 cột
                entity.HasIndex(p => new { p.ArticleId, p.TagId })
                      .IsUnique();
            });
        }
    }
}
