using System.Net;
using System.Text;

internal class Program
{
    static async Task Main(string[] args)
    {

        //  sử dụng HttpClientHandler để làm handler cho HttpClient, handler này có thiết lập để sử dụng Cookie gửi đi hoặc nhận về.
        //    var url = "https://postman-echo.com/post";
        //    // Tạo handler
        //    using HttpClientHandler handler = new HttpClientHandler();

        //    // Tạo bộ chứa cookie và sử dụng bởi handler
        //    CookieContainer cookies = new CookieContainer();
        //    // Thêm các cookie nêu muốn
        //    // cookies.Add(new Uri(url), new Cookie("name", "value"));

        //    handler.CookieContainer = cookies;

        //    // Tạo HttpClient - thiết lập handler cho nó
        //    using var httpClient = new HttpClient(handler);


        //    // Tạo HttpRequestMessage
        //    using var httpRequestMessage = new HttpRequestMessage();
        //    httpRequestMessage.Method = HttpMethod.Post;
        //    httpRequestMessage.RequestUri = new Uri(url);
        //    httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");
        //    var parameters = new List<KeyValuePair<string, string>>()
        //{
        //    new KeyValuePair<string, string>("key1", "value1"),
        //    new KeyValuePair<string, string>("key2", "value2")

        //};
        //    httpRequestMessage.Content = new FormUrlEncodedContent(parameters);

        //    // Thực hiện truy vấn
        //    var response = await httpClient.SendAsync(httpRequestMessage);

        //    // Hiện thị các cookie (các cookie trả về có thể sử dụng cho truy vấn tiếp theo)
        //    cookies.GetCookies(new Uri(url)).ToList().ForEach(cookie => {
        //        Console.WriteLine($"{cookie.Name} = {cookie.Value}");
        //    });

        //    // Đọc chuỗi nội dung trả về (HTML)
        //    var result = await response.Content.ReadAsStringAsync();
        //    Console.WriteLine(result);


        // handler SocketsHttpHandler sử dụng giống hệt HttpClientHandler nó được thiết kế để sử dụng tốt hơn - nhanh hơn trên .NET Core, nó độc lập thiết bị tốt hơn (chạy tốt trên macOS, Linux).
        //    var url = "https://postman-echo.com/post";
        //    // Tạo bộ chứa cookie và sử dụng bởi handler
        //    CookieContainer cookies = new CookieContainer();
        //    // Thêm các cookie nêu muốn
        //    // cookies.Add(new Uri(url), new Cookie("name", "value"));

        //    // Tạo handler
        //    using SocketsHttpHandler handler = new SocketsHttpHandler();
        //    handler.CookieContainer = cookies;     // Thay thế CookieContainer mặc định
        //    handler.AllowAutoRedirect = false;                // không cho tự động Redirect
        //    handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
        //    handler.UseCookies = true;

        //    // Tạo HttpClient - thiết lập handler cho nó
        //    using var httpClient = new HttpClient(handler);


        //    // Tạo HttpRequestMessage
        //    using var httpRequestMessage = new HttpRequestMessage();
        //    httpRequestMessage.Method = HttpMethod.Post;
        //    httpRequestMessage.RequestUri = new Uri(url);
        //    httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");
        //    httpRequestMessage.Headers.Add("Accept", "text/html,application/xhtml+xml+json");

        //    var parameters = new List<KeyValuePair<string, string>>()
        //{
        //    new KeyValuePair<string, string>("key1", "value1"),
        //    new KeyValuePair<string, string>("key2", "value2")

        //};
        //    httpRequestMessage.Content = new FormUrlEncodedContent(parameters);

        //    // Thực hiện truy vấn
        //    var response = await httpClient.SendAsync(httpRequestMessage);

        //    // Hiện thị các cookie (các cookie trả về có thể sử dụng cho truy vấn tiếp theo)
        //    cookies.GetCookies(new Uri(url)).ToList().ForEach(cookie => {
        //        Console.WriteLine($"{cookie.Name} = {cookie.Value}");
        //    });

        //    // Đọc chuỗi nội dung trả về (HTML)
        //    var result = await response.Content.ReadAsStringAsync();
        //    Console.WriteLine(result);




        // DelegatingHandler cho HttpClient: ) là một handler đặc biệt, nó như một MiddleWare để tạo ra một pipeline (chuỗi các handler). Mỗi đối tượng DelegatingHandler có một thuộc tính InnerHandler (kiểu HttpMessageHandler), phải được gán bằng một đối tượng SocketsHttpHandler, HttpClientHandler hoặc DelegatingHandler... Thiết lập InnerHandler qua phương thức khởi tạo lớp DelegatingHandler. Khi thực hiện truy vấn SendAsync thì nó tiếp tục gọi SendAsync trong InnerHandler, cứ như vậy nó sẽ tạo thành chuỗi.
        //Nếu InnerHandler không phải là một DelegatingHandler khác thì InnerHandler đó là handler dưới cùng của chuỗi handler. Request - respone sẽ đi qua chuỗi handler từ trên cùng xuống dưới khi truy vấn và ngược lại khi trả về.


        /*
          * Request  --> ......................  -->  .............  -->  .......................
                . DenyAccessFacebook .       . ChangeUri .       . MyHttpClientHandler .
            * Response <-- ......................  <--  .............  <--  .......................
         
         */

        string url = "https://www.facebook.com/xuanthulab";

        CookieContainer cookies = new CookieContainer();

        // TẠO CHUỖI HANDLER
        var bottomHandler = new MyHttpClientHandler(cookies);              // handler đáy (cuối)
        var changeUriHandler = new ChangeUri(bottomHandler);
        var denyAccessFacebook = new DenyAccessFacebook(changeUriHandler); // handler đỉnh

        // Khởi tạo HttpCliet với hander đỉnh chuỗi hander
        var httpClient = new HttpClient(denyAccessFacebook);

        // Thực hiện truy vấn
        httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml+json");
        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
        HttpResponseMessage response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string htmltext = await response.Content.ReadAsStringAsync();

        Console.WriteLine(htmltext);

    }


    public class MyHttpClientHandler : HttpClientHandler
    {
        public MyHttpClientHandler(CookieContainer cookie_container)
        {

            CookieContainer = cookie_container;     // Thay thế CookieContainer mặc định
            AllowAutoRedirect = false;                // không cho tự động Redirect
            AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            UseCookies = true;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                     CancellationToken cancellationToken)
        {
            Console.WriteLine("Bất đầu kết nối " + request.RequestUri.ToString());
            // Thực hiện truy vấn đến Server
            var response = await base.SendAsync(request, cancellationToken);
            Console.WriteLine("Hoàn thành tải dữ liệu");
            return response;
        }
    }

    public class ChangeUri : DelegatingHandler
    {
        public ChangeUri(HttpMessageHandler innerHandler) : base(innerHandler) { }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                               CancellationToken cancellationToken)
        {
            var host = request.RequestUri.Host.ToLower();
            Console.WriteLine($"Check in  ChangeUri - {host}");
            if (host.Contains("google.com"))
            {
                // Đổi địa chỉ truy cập từ google.com sang github
                request.RequestUri = new Uri("https://github.com/");
            }
            // Chuyển truy vấn cho base (thi hành InnerHandler)
            return base.SendAsync(request, cancellationToken);
        }
    }


    public class DenyAccessFacebook : DelegatingHandler
    {
        public DenyAccessFacebook(HttpMessageHandler innerHandler) : base(innerHandler) { }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                     CancellationToken cancellationToken)
        {

            var host = request.RequestUri.Host.ToLower();
            Console.WriteLine($"Check in DenyAccessFacebook - {host}");
            if (host.Contains("facebook.com"))
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new ByteArrayContent(Encoding.UTF8.GetBytes("Không được truy cập"));
                return await Task.FromResult<HttpResponseMessage>(response);
            }
            // Chuyển truy vấn cho base (thi hành InnerHandler)
            return await base.SendAsync(request, cancellationToken);
        }
    }
}