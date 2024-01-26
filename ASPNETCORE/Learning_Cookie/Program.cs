using Learning_Cookie.mylib;
using Newtonsoft.Json;

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
app.UseEndpoints((endpoint) =>
{
    endpoint.MapGet("/", async (context) =>
    {
        
        var menu = HtmlHelper.MenuTop(
            //new object[] {
            //    new
            //    {
            //        url = "/abc",
            //        label = "ABC"
            //    },
            //    new
            //    {
            //        url = "/xyz",
            //        label = "XYZ"
            //    }
            //}
            HtmlHelper.DefaultMenuTopItems() // Tạo ra những menu được define url sẵn ở HtmlHelper
            , context.Request
        );
        var html = HtmlHelper.HtmlDocument("Xin chao", menu + HtmlHelper.HtmlTrangchu());
        await context.Response.WriteAsync(html);
    });

    endpoint.MapGet("/RequestInfo", async (context) =>
    {
        var menu = HtmlHelper.MenuTop(
            HtmlHelper.DefaultMenuTopItems(), context.Request
        );
         var info = RequestProcess.RequestInfo(context.Request);

        var html = HtmlHelper.HtmlDocument("REQUESTINFO", menu + info.HtmlTag("div", "container"));
        await context.Response.WriteAsync(html);
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
        var menu = HtmlHelper.MenuTop(
            HtmlHelper.DefaultMenuTopItems(), context.Request
        );

        var p = new
        {
            TenSP = "Dong ho 123",
            Gia = 50000,
            NgaySX = new DateTime(2000, 12, 12)
        };
        var json = JsonConvert.SerializeObject(p);
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(json);
    });

    endpoint.MapGet("/Form", async (context) =>
    {
        await context.Response.WriteAsync("Form");
    });
});


app.UseAuthorization();

app.MapRazorPages();

app.Run();
