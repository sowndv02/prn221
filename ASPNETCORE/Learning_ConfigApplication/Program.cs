using Learning_ConfigApplication.Options;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/ShowOptions", async (context) =>
{
    // Thêm DI configuration
    var config = context.RequestServices.GetService<IConfiguration>();
    var testOptions = config.GetSection("TestOptions");
    var opt_key1 = testOptions["opt_key1"];
    var k1 = testOptions.GetSection("opt_key2")["k1"];
    var k2 = testOptions.GetSection("opt_key2")["k2"];

    var stringBuilder = new StringBuilder();
    stringBuilder.Append("TestOptions\n");
    stringBuilder.Append($"opt_key1 = {opt_key1}");
    stringBuilder.Append($"TestOptions.opt_key2.k1 = {k1}\n");
    stringBuilder.Append($"TestOptions.opt_key2.k2 = {k2}");

    await context.Response.WriteAsync( stringBuilder.ToString() );

});


app.Map("/ShowOptionsObject", appOptions => {
    appOptions.Run(async (context) => {

        StringBuilder stb = new StringBuilder();
        IConfiguration configuration = appOptions.ApplicationServices.GetService<IConfiguration>();

        TestOptions testoptions = configuration.GetSection("TestOptions").Get<TestOptions>();
        var opt_key1 = testoptions.opt_key1;
        var k1 = testoptions.opt_key2.k1;
        var k2 = testoptions.opt_key2.k2;

        stb.Append($"TestOptions.opt_key1:  {opt_key1}\n");
        stb.Append($"TestOptions.opt_key2.k1:  {k1}\n");
        stb.Append($"TestOptions.opt_key2.k2:  {k2}\n");

        await context.Response.WriteAsync(stb.ToString().HtmlTag("pre"));


    });
});
app.Run();
