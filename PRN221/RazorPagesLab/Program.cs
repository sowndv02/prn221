using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RazorPagesLab.Data;

namespace RazorPagesLab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var host = CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host);

            // Add services to the container.
            builder.Services.AddRazorPages();

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string ConnectionStr = config.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<SchoolContext>(options => options.UseSqlServer(ConnectionStr));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<StartupBase>();
            });

        private static void CreateDbIfNotExists(IHost host)
        {
            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SchoolContext>();
                    context.Database.EnsureCreated();
                    // DbInitializer.Initialize(context);  

                }catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

    }
}