using Learning_ASPNETCORE.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<SecondMiddleware>(); // Những middleware triển khai từ IMiddleware thì phải add vào container sau đó mới đưa vào đc pipeline

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles(); //StaticFileMiddleWare được lưu ở wwwroot => Chạy đầu tiên nếu có thì không thực hiện các Middleware phía sau nữa
/*Các middleware khác*/

app.UseMiddleware<FirstMiddleware>(); // Chạy qua đây sau đó mới đến các thằng sau

// app.UseFirstMiddleware(); // Sử dụng khi tạo ra 1 extension để sử dụng FirstMiddleware

app.UseMiddleware<SecondMiddleware>();

// app.UseSecondMiddleware(); // Sử dụng khi đã tạo extension để sử dụng SecondMiddleware


app.UseRouting(); // sử dụng EndpointRoutingMiddleWare =>  Tạo ra các điểm rẽ nhánh và các điểm rẽ nhánh đến terminate được khai báo bên dưới 
// Đôi khi ta không muốn rẽ nhánh đến terminate middleware luôn thì ta sử dụng Map
// Rẽ nhánh trong pipleline
app.Map("/admin", (app1) =>
{
    // Tạo ra middleware của nhánh. Nếu rẽ vào mà không có middleware nào được xử lý sẽ xảy ra lỗi. Do vậy ta sẽ tạo 1 terminate middleware để ngăn chặn lỗi
    
    app1.UseRouting();
    app1.UseEndpoints(endpoints =>
    {

        // BE1  
        endpoints.MapGet("/user", async context =>
        {
            await context.Response.WriteAsync("Trang quan ly user");
        });

        // BE1  
        endpoints.MapGet("/product", async context =>
        {
            await context.Response.WriteAsync("Trang quan ly san pham");
        });
    });
    
    
    // M2
    app1.Run(async (context) =>
    {
        await context.Response.WriteAsync("Trang admin");
    });
});
app.UseEndpoints((endpoint) =>
{
    //E1
    endpoint.MapGet("/about.html", async (context) =>
    {
        await context.Response.WriteAsync("Trang gioi thieu");
    });
    //E2
    endpoint.MapGet("/product.html", async (context) =>
    {
        await context.Response.WriteAsync("Trang san pham");
    });

    endpoint.MapGet("/RequestInfo", async (context) =>
    {
        await context.Response.WriteAsync("RequestInfo");
    });

    endpoint.MapGet("/Encoding", async (context) =>
    {
        await context.Response.WriteAsync("Encoding");
    });

    endpoint.MapGet("/Cookie", async (context) =>
    {
        await context.Response.WriteAsync("Cookie");
    });

    endpoint.MapGet("/Json", async (context) =>
    {
        await context.Response.WriteAsync("Json");
    });

    endpoint.MapGet("/Form", async (context) =>
    {
        await context.Response.WriteAsync("Form");
    });
});


app.UseAuthorization();

app.MapRazorPages();

// Terminate middleware M1: Không gọi đến các middleware phía sau
app.Run(async (context) =>
{
    context.Response.WriteAsync("Xin chao asp net core");
});



/*
 HttpContext
pipeline: StaticFileMiddleware - FirstMiddleware - SecondMiddleware - EndpointMiddleware (E1, E2) - M1
 Sử dụng webpack để biên dịch scss sang css và tự lưu vào folder wwwroot
 */