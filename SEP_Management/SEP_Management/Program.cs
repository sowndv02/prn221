using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Models;
using SEP_Management.Security.Requirements;
using SEP_Management.Services;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SEP_ManagementContextConnection") ?? throw new InvalidOperationException("Connection string 'SEP_ManagementContextConnection' not found.");

builder.Services.AddDbContext<SEP_ManagementContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<SEP_ManagementContext>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<IAuthorizationHandler, AppAuthorizationHandler>();

builder.Services.AddAuthentication()
    .AddGoogle(googleOptions =>
    {
        var googleAuthNSection = builder.Configuration.GetSection("Authentication:Google");
        googleOptions.ClientId = googleAuthNSection["ClientId"];
        googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];
    });


builder.Services.AddAuthorization(options =>
{
    //options.AddPolicy("NamePolicy", policyBuilder =>
    //{
    //    // Điều kiện của policy
    //});

    options.AddPolicy("AllowEditRole", policyBuilder =>
    {
        // Điều kiện của policy
        policyBuilder.RequireAuthenticatedUser(); // User phải đăng nhập
        policyBuilder.RequireRole("Admin"); // User phải có role là admin và editor 
        policyBuilder.RequireRole("Editor");

        policyBuilder.RequireClaim("NameClaim", "ValueClaim1", "ValueClaim2"); // Xác thực theo claim: Claim-based authorization
        policyBuilder.RequireClaim("NameClaim", new string[] { });
    });

    options.AddPolicy("AdminDropdown", policyBuilder =>
    {
        policyBuilder.RequireAuthenticatedUser();
    });

    options.AddPolicy("InGenZ", policyBuilder =>
    {
        policyBuilder.Requirements.Add(new GenZRequirements()); // Để kiểm tra được genZRequirements thì có các Authorization handler
    });


});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
    options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;
});


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
    options.Password.RequiredUniqueChars = 1;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;

    options.SignIn.RequireConfirmedEmail = true;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.SignIn.RequireConfirmedAccount = true;
});

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});

builder.Services.AddRazorPages();
builder.Services.AddOptions();
var mailsettings = builder.Configuration.GetSection("MailSettings");
builder.Services.Configure<MailSettings>(mailsettings);
builder.Services.AddTransient<IEmailSender, SendMailService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
