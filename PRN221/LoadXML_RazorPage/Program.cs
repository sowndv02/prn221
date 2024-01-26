using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LoadXML_RazorPage.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<LoadXML_RazorPageContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LoadXML_RazorPageContext") ?? throw new InvalidOperationException("Connection string 'LoadXML_RazorPageContext' not found.")));

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
