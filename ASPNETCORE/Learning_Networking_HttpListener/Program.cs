﻿using Newtonsoft.Json;
using System.Net;
using System.Text;

internal class Program
{

    // HttpListener giúp tạo ra dịch vụ với giao thức HTTP, nó lắng nghe các yêu cầu HTTP Request gửi đến và trả về HTTP Respone. Dịch vụ HTTP hoạt động và tồn tại cùng với sự tồn tại của đối tượng HttpListener.

    private static async Task Main(string[] args)
    {



        // tạo máy chủ Http cơ bản
        // Mảng chứa địa chỉ Http lắng nghe
        // http =  giao thức http, * = ip bất kỳ, 8080 = cổng lắng nghe
        //string[] prefixes = new string[] { "http://*:8080/" };

        //HttpListener listener = new HttpListener();

        //if (!HttpListener.IsSupported) throw new Exception("Hệ thống hỗ trợ HttpListener.");

        //if (prefixes == null || prefixes.Length == 0) throw new ArgumentException("prefixes");

        //foreach (string s in prefixes)
        //{
        //    listener.Prefixes.Add(s);
        //}

        //Console.WriteLine("Server start ...");

        //// Http bắt đầu lắng nghe truy vấn gửi đến
        //listener.Start();

        //// Vòng lặp chấp nhận và xử lý các client kết nối
        //do
        //{
        //    // Chấp nhận khi có cliet kết nối đế
        //    HttpListenerContext context = await listener.GetContextAsync();

        //    // ....
        //    // Xử lý context - đọc  thông tin request,  ghi thông tin response
        //    // ... ví dụ như sau:

        //    var response = context.Response;                                        // lấy HttpListenerResponse
        //    var outputstream = response.OutputStream;                               // lấy Stream lưu nội dung gửi cho client

        //    context.Response.Headers.Add("content-type", "text/html");              // thiết lập respone header
        //    byte[] buffer = System.Text.Encoding.UTF8.GetBytes("Hello world!");     // dữ liệu content
        //    response.ContentLength64 = buffer.Length;
        //    await outputstream.WriteAsync(buffer, 0, buffer.Length);                  // viết content ra stream
        //    outputstream.Close();                                                   // Đóng stream (gửi về cho cliet)

        //}
        //while (listener.IsListening);




        // tạo máy chủ HTTP đơn giản bằng HttpListener
        var server = new MyHttpServer(new string[] { "http://*:8080/" });
        await server.StartAsync();
    }

    // Chạy một HTTP Server, prefixes example: new string[] { "http://*:8080/" }
    class MyHttpServer
    {
        private HttpListener listener;

        public MyHttpServer(params string[] prefixes)
        {
            if (!HttpListener.IsSupported)
                throw new Exception("Máy không hỗ trợ HttpListener.");

            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            // Khởi tạo HttpListener
            listener = new HttpListener();
            foreach (string prefix in prefixes)
                listener.Prefixes.Add(prefix);

        }
        public async Task StartAsync()
        {
            // Bắt đầu lắng nghe kết nối HTTP
            listener.Start();
            do
            {

                try
                {
                    Console.WriteLine($"{DateTime.Now.ToLongTimeString()} : waiting a client connect");

                    // Một client kết nối đến
                    HttpListenerContext context = await listener.GetContextAsync();
                    await ProcessRequest(context);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("...");

            }
            while (listener.IsListening);
        }

        // Xử lý trả về nội dung tùy thuộc vào URL truy cập
        //      /               hiện thị dòng Hello World
        //      /stop           dừng máy chủ
        //      /json           trả về một nội dung json
        //      /anh2.png       trả về một file ảnh 
        //      /requestinfo    thông tin truy vấn
        async Task ProcessRequest(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            Console.WriteLine($"{request.HttpMethod} {request.RawUrl} {request.Url.AbsolutePath}");

            // Lấy stream / gửi dữ liệu về cho client
            var outputstream = response.OutputStream;


            switch (request.Url.AbsolutePath)
            {
                case "/requestinfo":
                    {
                        // Gửi thông tin về cho Client
                        context.Response.Headers.Add("content-type", "text/html");
                        context.Response.StatusCode = (int)HttpStatusCode.OK;

                        string responseString = this.GenerateHTML(request);
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                        response.ContentLength64 = buffer.Length;
                        await outputstream.WriteAsync(buffer, 0, buffer.Length);
                    }
                    break;
                case "/":
                    {
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes("Hello world!");
                        response.ContentLength64 = buffer.Length;
                        await outputstream.WriteAsync(buffer, 0, buffer.Length);
                    }
                    break;

                case "/stop":
                    {
                        listener.Stop();
                        Console.WriteLine("stop http");
                    }
                    break;

                case "/json":
                    {
                        response.Headers.Add("Content-Type", "application/json");
                        var product = new
                        {
                            Name = "Macbook Pro",
                            Price = 2000,
                            Manufacturer = "Apple"
                        };
                        string jsonstring = JsonConvert.SerializeObject(product);
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsonstring);
                        response.ContentLength64 = buffer.Length;
                        await outputstream.WriteAsync(buffer, 0, buffer.Length);

                    }
                    break;
                case "/anh2.png":
                    {
                        response.Headers.Add("Content-Type", "image/png");
                        byte[] buffer = await File.ReadAllBytesAsync("anh2.png");
                        response.ContentLength64 = buffer.Length;
                        await outputstream.WriteAsync(buffer, 0, buffer.Length);

                    }
                    break;

                default:
                    {
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes("NOT FOUND!");
                        response.ContentLength64 = buffer.Length;
                        await outputstream.WriteAsync(buffer, 0, buffer.Length);
                    }
                    break;
            }

            // switch (request.Url.AbsolutePath)


            // Đóng stream để hoàn thành gửi về client
            outputstream.Close();
        }

        // Tạo nội dung HTML trả về cho Client (HTML chứa thông tin về Request)
        public string GenerateHTML(HttpListenerRequest request)
        {
            string format = @"<!DOCTYPE html>
                            <html lang=""en""> 
                                <head>
                                    <meta charset=""UTF-8"">
                                    {0}
                                 </head> 
                                <body>
                                    {1}
                                </body> 
                            </html>";
            string head = "<title>Test WebServer</title>";
            var body = new StringBuilder();
            body.Append("<h1>Request Info</h1>");
            body.Append("<h2>Request Header:</h2>");

            // Header infomation
            var headers = from key in request.Headers.AllKeys
                          select $"<div>{key} : {string.Join(",", request.Headers.GetValues(key))}</div>";
            body.Append(string.Join("", headers));

            //Extract request properties
            body.Append("<h2>Request properties:</h2>");
            var properties = request.GetType().GetProperties();
            foreach (var property in properties)
            {
                var name_pro = property.Name;
                string value_pro;
                try
                {
                    value_pro = property.GetValue(request).ToString();
                }
                catch (Exception e)
                {
                    value_pro = e.Message;
                }
                body.Append($"<div>{name_pro} : {value_pro}</div>");

            };
            string html = string.Format(format, head, body.ToString());
            return html;
        }


    }
}