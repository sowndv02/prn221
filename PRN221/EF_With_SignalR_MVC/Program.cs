using EF_With_SignalR_MVC;
using EF_With_SignalR_MVC.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
string ConnectionStr = config.GetConnectionString("DefaultConnection");
builder.Services.AddSignalR();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionStr));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<SignalrServer>("/signalrServer");
app.Run();
