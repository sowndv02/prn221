using Learning_DI_ASPNETCORE.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Learning_DI_ASPNETCORE.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Learning_DI_ASPNETCOREContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Learning_DI_ASPNETCOREContext") ?? throw new InvalidOperationException("Connection string 'Learning_DI_ASPNETCOREContext' not found.")));

builder.Services.AddSingleton<ProductServices>();

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
