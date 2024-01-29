using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_EF.Models
{
    public class ShopContext : DbContext
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
        public DbSet<Category> categories { get; set; }

        public DbSet<CategoryDetail> categoryDetails { get; set; }

        private const string connectionString = "server=DESKTOP-V87NI7H\\SQLEXPRESS;database=shop01;user=sa;password=sa123456";
        //private const string connectionString = "server=COOKIE\\SQLEXPRESS;database=shop01;user=sa;password=123456";

        // Khi BbContext duoc tao thi no se duoc chay
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            // lam viec voi sql server
            optionsBuilder.UseSqlServer(connectionString);

            // Áp dụng lazyloađ
            optionsBuilder.UseLazyLoadingProxies();

        }


        // Ghi đè để sử dụng Fluent API
        // Các method sẻ được call trong này
        // Nó sẽ được thực thi sau khi thực thi OnConfiguring
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API
            // Entity => Fluent API => Product
            // c1
            // var entity = modelBuilder.Entity(typeof(Product));


            // c2
            // var entity = modelBuilder.Entity<Product>();

            //c3
            modelBuilder.Entity<Product>(entity =>
            {
                // entity -> Fluent API
                // Table Mapping
                entity.ToTable("Product"); // Thay cho table name
                entity.HasKey(p => p.Id); // Thay cho PK
                entity.HasIndex(p => p.Price).HasDatabaseName("index-product-price"); // Đánh index mà attribute kh làm đc. Đặt tên cho index
                entity.HasOne(p=>p.Category)//Thay FK
                .WithMany()                 // CategoryId đầu tiên kh có list products
                .HasForeignKey("CateId")    // Set col name0 attribute cho FK  mà kh tự gen    
                .OnDelete(DeleteBehavior.Cascade)       // Thiết lập action khi xóa    
                .HasConstraintName("FK_P_C"); // Set name FK                


                entity.HasOne(p => p.Category2)
                .WithMany("Products")           // Lấy ra products theo CateId2
                .HasForeignKey("CateId2")
                .OnDelete(DeleteBehavior.NoAction);


                entity.Property(p => p.Name)
                .HasColumnName("ProductName")           // Set col name cho attributeName. Ghi đè lên atribute. FluentAPI là kq cuối
                .HasColumnType("nvarchar")      // Set datatype
                .HasMaxLength(60)               // Set length
                .IsRequired(true)               // set required
                .HasDefaultValue("ProductName hihi"); // Default value


                // Mqh 1:1
                modelBuilder.Entity<CategoryDetail>(entity => 
                {
                    entity.HasOne(d => d.Category)
                    .WithOne(c => c.CategoryDetail)
                    .HasForeignKey<Category>(c => c.Id) // Khóa ngoại nằm ở bảng nào
                    .OnDelete(DeleteBehavior.Cascade);
                });



            });

        }

    }
}
