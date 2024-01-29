using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_EF.Models
{
    public class ProductDBContext  : DbContext
    {
        // Hiển thị query
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => 
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            builder.AddFilter(DbLoggerCategory.Database.Name, LogLevel.Information);
            builder.AddConsole();
            
        });

        // Khai bao table
        public DbSet<Product> products { get; set; }

        private const string connectionString = "server=DESKTOP-V87NI7H\\SQLEXPRESS;database=data01;user=sa;password=sa123456";
        //private const string connectionString = "server=COOKIE\\SQLEXPRESS;database=data01;user=sa;password=123456";

        // Khi BbContext duoc tao thi no se duoc chay
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            // lam viec voi sql server
            optionsBuilder.UseSqlServer(connectionString);
        }





    }
}
