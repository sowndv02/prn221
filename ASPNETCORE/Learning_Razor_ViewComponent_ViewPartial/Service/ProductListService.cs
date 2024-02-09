using Learning_Razor_ViewComponent_ViewPartial.Models;
using System.Xml.Linq;

namespace Learning_Razor_ViewComponent_ViewPartial.Service
{
    public class ProductListService
    {
        public List<Product> products { get; set; } = new List<Product>()
        {
            new Product() { Name = "ProductName1", Description = "Product1", Price = 1 },
            new Product() { Name = "ProductName2", Description = "Product2", Price = 2 },
            new Product() { Name = "ProductName3", Description = "Product3", Price = 3 }
        };
    }
}
