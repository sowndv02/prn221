var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorPagesOptions(option =>
{
    option.RootDirectory = "/Razor";// Đổi thư mục chứa các trang razor 
    option.Conventions.AddPageRoute("/FirstPage", "trang-dau-tien.html"); // Rewrite URL hoặc thiết lập trong chính trang razor
}); 

builder.Services.AddRazorPages(); // 
builder.Services.Configure<RouteOptions>(RouteOptions =>
{
    RouteOptions.LowercaseUrls = true; // Chuyển các url thành in thường
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages(); // Tìm trên toàn bộ mã nguồn coi toàn bộ trang là endpoint với URL là tên file

app.Run();


/*
Razor page - (.cshtml)  = html + C#
Engine Razor -> biên dịch cshtml -> Response
- @page
- @bien, @(bieu-thuc), @phuong-thuc
- TagHelper
- ViewData["key"]
- _Layout.cshtml: để dấu _ để không tạo endpoint và đc sử dụng chung
- _ViewStart.cshtml: Để khi call đến thằng cùng folder tự add layout
- _ViewImports.cshtml: Tương tự ViewStart nhưng chỉ chấp nhận add @addTagHelper, @using, @inject
 */