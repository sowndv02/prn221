using Learning_EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

internal class Program
{
    //private static void Main(string[] args)
    //{
    //    // Entity => Database, Table
    //    // Database - SQL Server : data01 -> DBContext

    //    var productDbContext = new ProductDBContext();
    //}

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

    static void InsertProduct()
    {
        using var dbcontext = new ProductDBContext();
        /*
         - Model (Product)
        - Add, AddAsync
        = SaveChange
         */

        var p1 = new Product { Id = 1, Name = "Product1", Price = 12121 };
        dbcontext.products.Add(p1);
        int inssert_row = dbcontext.SaveChanges();
        Console.WriteLine(inssert_row);
    }

    public static async Task ReadProducts()
    {
        using (var context = new ProductDBContext())
        {
            // context.SetLogging();
            // Lấy danh sách các sản phẩm trong bảng 
            var products = await context.products.ToListAsync();

            Console.WriteLine("Tất cả sản phẩm");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id,2} {product.Name,10} - {product.Price}");
            }
            Console.WriteLine();
            Console.WriteLine();

            // Dùng LINQ để truy vấn đến DbSet products (bảng product)
            // Lấy các sản phẩm cung cấp bởi CTY A 
            products = await (from p in context.products
                              where (p.Price == 2143)
                              select p
                             )
                            .ToListAsync();

            // Nếu không dùng bất đồng bộ chỗ này, có thể dùng
            // var pros = from p in context.products where (p.Provider == "CTY A") select p;

            Console.WriteLine("Sản phẩm CTY A");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id,2} {product.Name,10} - {product.Price}");
            }
        }
    }

    // Đổi tên sản phẩm có ProductID thành  tên mới
    public static async Task RenameProduct(int id, string newName)
    {
        using (var context = new ProductDBContext())
        {

            // Lấy  Product có  ID sản phẩm  chỉ  ra
            var product = await (from p in context.products where (p.Id == id) select p).FirstOrDefaultAsync();

            // Đổi tên và cập nhật


            // Khi lấy được product thì DBcontext sẽ theo dõi trạng thái của product
            if (product != null)
            {
                // Cách 1 cập nhật từng phần tử
                //product.Name = newName;
                //Console.WriteLine($"{product.Id,2} có tên mới = {product.Name,10}");
                //await context.SaveChangesAsync();  //Thi hành cập nhật


                EntityEntry<Product> entry = context.Entry(product);
                // Không cho DBcontext theo dõi nữa
                entry.State = EntityState.Detached;


                
                // Tạo đối tượng
                var pr = new Product()
                {
                    Id = 4,
                    Name = "Abc"
                };
                // Gắn pr vào context để theo dõi, nó trả vể đối tượng EntityEntry<Product>
                EntityEntry<Product> pr_e = context.Attach(pr);

                // Lấy thuộc tính Name của Product và thiết lập nó cần cập nhật
                // với IsModified  = true;
                pr_e.Property(p => p.Name).IsModified = true;
                context.SaveChanges();

            }
        }
    }


    // Xóa sản phẩm có ProductID = id
    public static async Task DeleteProduct(int id)
    {
        using (var context = new ProductDBContext())
        {
            // context.SetLogging();
            var product = await (from p in context.products where (p.Id == id) select p).FirstOrDefaultAsync();

            if (product != null)
            {
                context.Remove(product);
                Console.WriteLine($"Xóa {product.Id}");
                await context.SaveChangesAsync();
            }
        }
    }



}