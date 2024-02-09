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

app.UseAuthorization();

app.MapRazorPages();

app.Run();

/*

Page Model: Đa học ở các bài trc chỉ ôn lại
Model Binding: Liên kết dư liệu
- Dự liệu gửi đến: {key, value}
- Nguồn:
    + Form Html (post)              - HttpRequest.Form["key"]
    + Query (form html - get)       - HttpRequest.Query["key"]
    + Header                        - HttpRequest.Header["key"]
    + Route data                    - HttpRequest.RouteValues["key"]
    + Upload file
    + Body  

- Đọc dư liệu: HttpRequest

- Để binding data thì ta có attribute: Parameter Binding, Properties binding
- Binding thực hiện tự động
- Nếu có trên query và route thì se đọc ở route trước và kh đọc ở query nưa
- nẾu muốn chỉ ro thì sử dụng [FrômQuery], [FromRoute].....
- Trong TH binding nhưng data phức tạp như object thì chúng ta có thể chỉ ra binding 1 vài thuộc tính chứ kh phải tất cả bằng [Bind("Id", "Name")]

- Để binding bằng properties thì phải thêm [BindProperty(SupportGet = true)] - mặc định là post nếu muốn thì phải sử dụng 

 */
