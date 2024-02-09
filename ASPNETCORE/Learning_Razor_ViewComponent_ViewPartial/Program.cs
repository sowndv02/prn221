using Learning_Razor_ViewComponent_ViewPartial.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<ProductListService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


/*
 PartialView : là file cshtml không có @page
    - Chia nhỏ các file @page thành các file nhỏ
    - Để tái sử dụng mà kh phải viết code nhiều lần 
 syntax: 
    <partial name="_productItem" model="product1" />: tìm trong hệ thống có productItem không
    @await Html.PartialAsync("_productItems", product2)
    @{
        await Html.RenderPartialAsync("productItems", product3);
    }

Component ~ partialview  ~ DI  = Mini Razor Page
 */