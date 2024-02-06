/*
 
inclue 2 pakage để sử dụng session
dotnet add package Microsoft.AspNetCore.Session
dotnet add package Microsoft.Extensions.Caching.Memory
 
include thư viện để lưu session trong sql server
dotnet new tool-manifest
dotnet tool install --local dotnet-sql-cache --version 6.0.6


dotnet sql-cache create "connectionString" dbo Session -- Để tạo bảng lưu session trong sql server

dotnet Microsoft.Extensions.Caching.SqlServer
 */


var builder = WebApplication.CreateBuilder(args);

//  builder.Services.AddDistributedMemoryCache(); // Sử dụng memory cache lưu
builder.Services.AddDistributedSqlServerCache((option) =>
{
    option.ConnectionString = "";
    option.SchemaName = "dbo";
    option.TableName = "Session";
});
builder.Services.AddSession((option) =>
{
    option.Cookie.Name = "test";
    option.IdleTimeout = new TimeSpan(0, 30, 0);
});

var app = builder.Build();
app.UseRouting();
app.UseSession();

app.UseEndpoints(endpoint =>
{
    endpoint.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Hello world!");
    });

    endpoint.MapGet("/Session", async (context) =>
    {
        int? count;
        count = context.Session.GetInt32("count"); // Get session
        if (count == null)
        {
            count = 0;
        }

        count++;
        context.Session.SetInt32("count", count.Value); // Lưu session
        //context.Session.SetString - Lưu Json

        await context.Response.WriteAsync($"Count: {count}");
    });
});

app.Run();
