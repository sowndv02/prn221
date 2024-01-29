using Learning_EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_EF
{
    public class MainProgram
    {

        // install lib
        /*
        dotnet add package Microsoft.EntityFrameworkCore.Proxies 
        dotnet add package System.Data.SqlClient
        dotnet add package Microsoft.EntityFrameworkCore
        dotnet add package Microsoft.EntityFrameworkCore.SqlServer
        dotnet add package Microsoft.EntityFrameworkCore.Design
        dotnet add package Microsoft.Extensions.DependencyInjection
        dotnet add package Microsoft.Extensions.Logging
        dotnet add package Microsoft.Extensions.Logging.Console
         */
        //public static void Main(string[] args)
        //{
        //    CreateDatabase();
        //    InsertSampleData();



        //    using var context = new ShopContext();
        //    var product = context.products.FirstOrDefault(x => x.Id == 3);
            
        //    // theo dõi product vừa lấy ra
        //    var e = context.Entry(product); 
        //    // Load thêm thuộc tính category
        //    e.Reference(p => p.Category).Load();

        //    var category = context.categories.FirstOrDefault(x => x.Id == 3);
        //    var f = context.Entry(category);
        //    f.Reference(c => c.Products).Load();
        //}

        // Chèn dữ liệu mẫu
        public static void InsertSampleData()
        {
            using var context = new ShopContext();
            // Thêm 2 danh mục vào Category
            var cate1 = new Category() { Name = "Cate1", Description = "Description1" };
            var cate2 = new Category() { Name = "Cate2", Description = "Description2" };
            context.AddRange(cate1, cate2);
            context.SaveChanges();

            // Thêm 5 sản phẩm vào Products
            context.AddRange(
                new Product() { Name = "Sản phẩm 1", Price = 12, Category = cate2 },
                new Product() { Name = "Sản phẩm 2", Price = 11, Category = cate2 },
                new Product() { Name = "Sản phẩm 3", Price = 33, Category = cate2 },
                new Product() { Name = "Sản phẩm 4(1)", Price = 323, Category = cate1 },
                new Product() { Name = "Sản phẩm 5(1)", Price = 333, Category = cate1 }

            );
            context.SaveChanges();
            // Các sản phầm chèn vào
            foreach (var item in context.products)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append($"ID: {item.Id}");
                stringBuilder.Append($"tên: {item.Name}");
                stringBuilder.Append($"Danh mục {item.Category.Id}({item.Category.Name})");
                Console.WriteLine(stringBuilder);
            }

            // ID: 1tên: Sản phẩm 2Danh mục 2(Cate2)
            // ID: 2tên: Sản phẩm 1Danh mục 2(Cate2)
            // ID: 3tên: Sản phẩm 3Danh mục 2(Cate2)
            // ID: 4tên: Sản phẩm 4(1)Danh mục 1(Cate1)
            // ID: 5tên: Sản phẩm 5(1)Danh mục 1(Cate1)

        }

        static void CreateDatabase()
        {
            using var dbcontext = new ProductDBContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;

            // Kiểm tra xem server có chưa nếu chưa thì tạo
            var result = dbcontext.Database.EnsureCreated();
            if (result) Console.WriteLine("Done");
            else Console.WriteLine("Nothing");
            Console.WriteLine(dbname);
        }


        static void DeleteDatabase()
        {
            using var dbcontext = new ProductDBContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;

            // Kiểm tra xem server có chưa nếu chưa thì tạo
            var result = dbcontext.Database.EnsureDeleted();
            if (result) Console.WriteLine("Done");
            else Console.WriteLine("Nothing");
            Console.WriteLine(dbname);
        }
    }
}
