var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

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
 Layout: bố cục trang = header, footer, menu
Nếu ViewStart sử dụng layout và trong page sử dụng layout khác thì sẽ lấy layout của page chứ kh sử dụng của viewstart nữa 
@RenderSection("sectionName", required: bool)
 */