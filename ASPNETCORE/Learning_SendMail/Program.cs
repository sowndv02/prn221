using Learning_SendMail.MailUtils;
using Learning_SendMail.Service;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Read mail settings from configuration
var mailSettings = builder.Configuration.GetSection("MailSettings").Get<MailSetting>();
builder.Services.AddSingleton(mailSettings);

builder.Services.AddTransient<SendMailService>();

var app = builder.Build();
/*
 
Mail Server - Smtp
SmtpClient 

Server: Mail transporter (QMail, SendMail, CenterOS)
 
 */


app.MapGet("/", () => "Hello World!");
app.MapGet("/SendMail", async (context) =>
{
   var message = await MailUtils.SendMail("daoson03112002@gmail.com", "sondvhe164023@fpt.edu.vn", "Send Mail C#", "Learning C#");
   await context.Response.WriteAsync(message);
});
app.MapGet("/SendGmail", async (context) =>
{
    var message = await MailUtils.SendGmail("sendotp1234@gmail.com", "sondvhe164023@fpt.edu.vn", "Send Mail C#", "Learning C#", "sendotp1234@gmail.com", "tcdpochkbrgocdrm");
    await context.Response.WriteAsync(message);
});

app.MapGet("/SendMailKit", async (context) =>
{
    var sendMailService = context.RequestServices.GetService<SendMailService>();
    MailContent mailContent = new MailContent();
    mailContent.Subject = "Test";
    mailContent.To = "daoson03112002@gmail.com";
    mailContent.Body = "<h1>Test<h1>";
    var result = await sendMailService.SendMail(mailContent);
    await context.Response.WriteAsync(result);
});

app.Run();
