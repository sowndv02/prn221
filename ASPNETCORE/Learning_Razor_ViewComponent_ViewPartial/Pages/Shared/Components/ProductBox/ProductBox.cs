using Learning_Razor_ViewComponent_ViewPartial.Models;
using Learning_Razor_ViewComponent_ViewPartial.Service;
using Microsoft.AspNetCore.Mvc;

namespace Learning_Razor_ViewComponent_ViewPartial.Pages.Shared.Components.ProductBox
{
    //[ViewComponent]
    public class ProductBox : ViewComponent
    {
        // Điều kiện đầu tiên phải có 1 trong 2 method này
        // Invoke(object m): Phải trả về string hoặc IViewcomponentResult
        // InvokeAsync()
        // Điều kiện thứ 2 là phải có [ViewComponent] hoặc có hậu tố của tên class là ViewComponent hoặc kế thừa ViewComponent

        ProductListService productService;
        public ProductBox(ProductListService products) 
        {
            productService = products;
        }

        public IViewComponentResult Invoke(bool orderPrice = true)
        {
            //return View<string>("Day la lay tu model"); // nêu không set thì tự gọi Default.cshtml
            
            List<Product> order;
            if (orderPrice)
            {
                order = productService.products.OrderBy(p => p.Price).ToList();
            }
            else
            {
                order = productService.products.OrderByDescending(p => p.Price).ToList();  
            }
            return View<List<Product>>(order);
        }
    }
}
