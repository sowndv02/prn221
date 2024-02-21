

using EntityFramework_With_SignalR.Models;
using EntityFramework_With_SignalR.SignalRConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddDbContext<PRN211_1Context>();

builder.Services.AddSingleton<SignalrServer>();

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<SignalrServer>("/signalrServer");
});
app.MapRazorPages();

app.Run();
