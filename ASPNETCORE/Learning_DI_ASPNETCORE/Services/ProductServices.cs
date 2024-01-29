using System.Security.Cryptography.X509Certificates;

namespace Learning_DI_ASPNETCORE.Services
{

    public class Product 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price {  get; set; }  
    }

    public class ProductServices
    {
        List<Product> products = new List<Product>();

        public ProductServices()
        {
            products.AddRange(new Product[]
            {
                new Product(){Id = "product01", Name = "Dien thoai 1", Price = 1000},
                new Product(){Id = "product02", Name = "Dien thoai 2", Price = 1000}
            });
        }

        public Product FindProduct(string productId)
        {
            return products.FirstOrDefault(x => x.Id == productId);
        }

    }
}
