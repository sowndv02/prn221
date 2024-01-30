﻿using Learning_Cookie.mylib;
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



    // Cookies/Write
    // Cookies/Read
    endpoint.MapGet("/Cookies/{*action}", async (context) =>
    {
        string msg = "";
        var menu = HtmlHelper.MenuTop(
            HtmlHelper.DefaultMenuTopItems(), context.Request
        );
        var info = RequestProcess.RequestInfo(context.Request);

        var action = context.GetRouteValue("action") ?? "Read";

        if(action.ToString() == "Write")
        {
            // Tên - giá trị - Thời gian hiệu lực
            var option = new CookieOptions()
            {
                Path = "/",
                Expires = DateTime.Now.AddDays(1)
            };
            context.Response.Cookies.Append("product", "123212", option);
            msg = "Cookie read successfully";
        }
        else
        {
            // Lấy danh sách các Header và giá trị  của nó, dùng Linq để lấy
            var listcokie = context.Request.Cookies.Select((header) => $"{header.Key}: {header.Value}".HtmlTag("li"));
            var cockiesHtml = string.Join("", listcokie).HtmlTag("ul");
        }
        var path = "<a class=\"btn btn-primary\" href=\"/Cookies/read\">Read cookies</a><a class=\"btn btn-danger\" href=\"/Cookies/Write\">Write cookies</a>";
        path.HtmlTag("div", "container mt-4");
        var html = HtmlHelper.HtmlDocument("COOKIE", menu + info.HtmlTag("div", "container"));
        await context.Response.WriteAsync(html);
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
        string menu = HtmlHelper.MenuTop(HtmlHelper.DefaultMenuTopItems(), context.Request);
        string formhtml = await RequestProcess.FormProcess(context.Request);
        formhtml = formhtml.HtmlTag("div", "container");
        string html = HtmlHelper.HtmlDocument("Form Post", (menu + formhtml));
        await context.Response.WriteAsync(html);
    });
});


app.UseAuthorization();

app.MapRazorPages();

app.Run();
