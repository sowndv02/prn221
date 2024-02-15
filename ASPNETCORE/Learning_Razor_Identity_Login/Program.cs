using Learning_Razor_Identity_Login.Data;
using Learning_Razor_Identity_Login.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//// Add Login other service
//builder.Services.AddAuthentication()
//    .AddGoogle(googleOptions =>
//    {
//        /*
//         - Có 2 lý do có thể kh login đc
//            + Có tài khoản, chưa lk với dịch vụ ngoài => Liên kết tk với dịch vụ
//            + Chưa có tk => Tạo tk, liên kết, đăng nhập
//        */ 
//        // Đọc thông tin Authentication:Google từ appsettings.json
//        IConfigurationSection googleAuthNSection = Configuration.GetSection("Authentication:Google");

//        // Thiết lập ClientID và ClientSecret để truy cập API google
//        googleOptions.ClientId = googleAuthNSection["ClientId"];
//        googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];
//        // Cấu hình Url callback lại từ Google (không thiết lập thì mặc định là /signin-google)
//        googleOptions.CallbackPath = "/dang-nhap-tu-google";

//    });
// Đăng ký Idenetity
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<MyBlogContext>()
    .AddDefaultTokenProviders();


// Tạo policy
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
        policyBuilder.RequireClaim("NameClaim", new string[] {}); 
    });

});

// Sử dụng UI 
//builder.Services.AddDefaultIdentity<AppUser>()
//    .AddEntityFrameworkStores<MyBlogContext>()
//    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(option =>
{
    option.LoginPath = "/Identity/Account/Login";
    option.LogoutPath = "/Identity/Account/Logout";
    option.AccessDeniedPath = "/Identity/Account/AccessDenied";

});


// Truy cập IdentityOptions
builder.Services.Configure<IdentityOptions>(options => {
    // Thiết lập về Password
    options.Password.RequireDigit = false; // Không bắt phải có số
    options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
    options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
    options.Password.RequireUppercase = false; // Không bắt buộc chữ in
    options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
    options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

    // Cấu hình Lockout - khóa user
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
    options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
    options.Lockout.AllowedForNewUsers = true;

    // Cấu hình về User.
    options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;  // Email là duy nhất

    //// Cấu hình đăng nhập.
    //options.SignIn.RequireConfirmedEmail = true;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
    //options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại
    //options.SignIn.RequireConfirmedAccount = true; // Để xác thực email thì mới cho login
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

/*
Identity

dotnet add package System.Data.SqlClient
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.Extensions.DependencyInjection
dotnet add package Microsoft.Extensions.Logging.Console

dotnet add package Microsoft.AspNetCore.Identity
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.AspNetCore.Identity.UI
dotnet add package Microsoft.AspNetCore.Authentication
dotnet add package Microsoft.AspNetCore.Http.Abstractions
dotnet add package Microsoft.AspNetCore.Authentication.Cookies
dotnet add package Microsoft.AspNetCore.Authentication.Facebook
dotnet add package Microsoft.AspNetCore.Authentication.Google
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Microsoft.AspNetCore.Authentication.MicrosoftAccount
dotnet add package Microsoft.AspNetCore.Authentication.oAuth
dotnet add package Microsoft.AspNetCore.Authentication.OpenIDConnect
dotnet add package Microsoft.AspNetCore.Authentication.Twitter
dotnet add package MailKit
dotnet add package MimeKit
dotnet add package Microsoft.AspNetCore.Authentication.Facebook
dotnet add package Microsoft.AspNetCore.Authentication.Google
dotnet add package Microsoft.AspNetCore.Authentication.MicrosoftAccount
dotnet add package Microsoft.AspNetCore.Authentication.Twitter



- Hô trợ
    - Authentication: Xác thực danh tính: Login, Logout
    - Authorization: Xác thực quyền truy cập
        + Role-Base authorization - xác thực theo vai trò
            Role: Index, Create, Edit, Delete
            [Authorize(Roles = "role1,role2")]: user phải đăng nhập và có 1 tron các role sau sẽ được đăng nhập
            Nếu tách ra từng dòng thì se yc user phải có tất cả role đó mới đc truy cập
        + Policy-based authorization: 
            [Authorize(Policy = "AllowEditRole")]: cho phép user có policy thoả man thì edit 
        + Claims-based authorization: 
            Claim: Đặc tính, tính chất của 1 đối tượng 
            Ex:
                Bằng lái B2(Role): Được lái xe 4 chô
                    Trên bằng B2 có: Ngày sinh, giới tính..... => Claim
                Mua rượu ( > 18 tuổi)
                    Kiểm tra ngày sinh: Claim-based authorization


    - Quản lý user: Sigin up, User, Role....

- DB
    - IdentityUser: CSDL chứa các thông tin của user
    - IdentityDbContext: Làm việc với CSDL trên se cho kế thừa tư DBContext mình tạo để có cả db của identityUser


- URL
    - Identity/Account/Login 
    - Identity/Account/Manage

- Gen UI
dotnet aspnet-codegenerator identity -dc Album.Data.AppDbContext
Tham số -dc Album.Data.AppDbContext để chỉ ra là Identity sử dụng DbContext là Album.Data.AppDbContext của chúng ta xây dựng ở trên


 */
