using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Networking_HTTP
{
    public class HttpRequest_Demo
    {
        public static async Task Main(string[] args)
        {
            // Http Request - HttpClient(GET/POST/PUT....)

            //// Khởi tạo http client
            //using var httpClient = new HttpClient();

            //// Thiết lập các Header nếu cần
            //httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml+json");

            //// Thực hiện truy vấn GET
            //HttpResponseMessage response = await HttpClient.GetAsync(url);
            //// Từ đây có thể đọc được response trả về


            //var url = "https://www.google.com/search?q=youtube";
            //var html = await GetWebContent(url);
            //Console.WriteLine(html);

            // DownloadDataStream trả về một Stream để đọc Content
            //var url = "https://raw.githubusercontent.com/xuanthulabnet/linux-centos/master/docs/samba1.png";
            //await DownloadDataStream(url, "anh2.png");

            // Tạo request với SendAsync
            //HttpClient client = new HttpClient();
            //var httpRequestMessage = new HttpRequestMessage();
            //httpRequestMessage.Method = HttpMethod.Post;
            //httpRequestMessage.RequestUri = new Uri("https://xuanthulab.net");
            //// Add các header ở đây
            //var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            //ShowHeaders(httpResponseMessage.Headers);
            //var html = httpResponseMessage.Content.ReadAsStringAsync();
            //Console.WriteLine(html);




            // Sử dụng FormUrlEncodedContent: Để thiết lập Content trong HttpRequestMessage để gửi đến server thì thiết lập thuộc tính Content bằng các đối tượng thuộc các lớp như: FormUrlEncodedContent, StringContent,

            /*
             key1 => value1  [Input]
            key2 => [value2-1, value2-2] [Multí select] 
             */
            //var httpClient = new HttpClient();

            //var httpRequestMessage = new HttpRequestMessage();
            //httpRequestMessage.Method = HttpMethod.Post;
            //httpRequestMessage.RequestUri = new Uri("https://postman-echo.com/post");

            //var parameters = new List<KeyValuePair<string, string>>();
            //parameters.Add(new KeyValuePair<string, string>("key1", "value1"));

            //parameters.Add(new KeyValuePair<string, string>("key2", "value2-1"));
            //parameters.Add(new KeyValuePair<string, string>("key2", "value2-2"));

            //// Thiết lập Content
            //var content = new FormUrlEncodedContent(parameters);
            //httpRequestMessage.Content = content;

            //// Thực hiện Post
            //var response = await httpClient.SendAsync(httpRequestMessage);

            //var responseContent = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(responseContent);
            //// Khi chạy kết quả trả về cho biết Server đã nhận được dữ liệu Post đến



            // Sử dụng StringContent: sử dụng cách này để tạo truy vấn Webservice API với Content là JSON
            //var httpClient = new HttpClient();

            //var httpRequestMessage = new HttpRequestMessage();
            //httpRequestMessage.Method = HttpMethod.Post;
            //httpRequestMessage.RequestUri = new Uri("https://postman-echo.com/post");

            //// Tạo StringContent
            //string jsoncontent = "{\"value1\": \"giatri1\", \"value2\": \"giatri2\"}";
            //var httpContent = new StringContent(jsoncontent, Encoding.UTF8, "application/json");
            //httpRequestMessage.Content = httpContent;

            //var response = await httpClient.SendAsync(httpRequestMessage);
            //var responseContent = await response.Content.ReadAsStringAsync();

            //Console.WriteLine(responseContent);




            //  MultipartFormDataContent: Bạn có thể gán Content bằng đối tượng kiểu MultipartFormDataContent, để post dữ liệu nhiều thành phần (multipart/form-data), vừa có dữ liệu như các phần tử của HTML Form vừa có thể kèm file.

            var httpClient = new HttpClient();

            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri("https://postman-echo.com/post");


            // Tạo đối tượng MultipartFormDataContent
            var content = new MultipartFormDataContent();

            // Tạo StreamContent chứa nội dung file upload, sau đó đưa vào content
            Stream fileStream = System.IO.File.OpenRead("Program.cs");
            content.Add(new StreamContent(fileStream), "fileupload", "abc.xyz");

            // Thêm vào MultipartFormDataContent một StringContent
            content.Add(new StringContent("value1"), "key1");
            // Thêm phần tử chứa mạng giá trị (HTML Multi Select)
            content.Add(new StringContent("value2-1"), "key2[]");
            content.Add(new StringContent("value2-2"), "key2[]");


            httpRequestMessage.Content = content;
            var response = await httpClient.SendAsync(httpRequestMessage);
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);




        }


        // Tải từ url, trả về stream để đọc dữ liệu (xem bài về stream)
        public static async Task DownloadDataStream(string url, string filename)
        {
            var httpClient = new HttpClient();
            Console.WriteLine($"Starting connect {url}");
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // Lấy Stream để đọc content
                using var stream = await response.Content.ReadAsStreamAsync();

                // THỰC HIỆN ĐỌC Content
                int SIZEBUFFER = 500;
                using var streamwrite = File.OpenWrite(filename);  // Mở stream để lưu file
                byte[] buffer = new byte[SIZEBUFFER];               // tạo bộ nhớ đệm lưu dữ liệu khi đọc stream

                bool endread = false;
                do                                                  // thực hiện đọc các byte từ stream và lưu ra streamwrite
                {
                    int numberRead = await stream.ReadAsync(buffer, 0, SIZEBUFFER);
                    Console.WriteLine(numberRead);
                    if (numberRead == 0)
                    {
                        endread = true;
                    }
                    else
                    {
                        await streamwrite.WriteAsync(buffer, 0, numberRead);
                    }

                } while (!endread);
                Console.WriteLine("Download success");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        /// In ra thông tin các Header của HTTP Response
        public static void ShowHeaders(HttpHeaders headers)
        {
            Console.WriteLine("CÁC HEADER:");
            foreach (var header in headers)
            {
                foreach (var value in header.Value)
                {
                    Console.WriteLine($"{header.Key,25} : {value}");

                }
            }
            Console.WriteLine();
        }

        // Tải về trang web và trả về chuỗi nội dung
        public static async Task<string> GetWebContent(string url)
        {
            // Khởi tạo http client
            using var httpClient = new HttpClient();

            // Thiết lập các Header nếu cần
            httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml+json");
            try
            {
                // Thực hiện truy vấn GET
                HttpResponseMessage response = await httpClient.GetAsync(url);

                // Hiện thị thông tin header trả về
                ShowHeaders(response.Headers);

                // Phát sinh Exception nếu mã trạng thái trả về là lỗi
                response.EnsureSuccessStatusCode();

                Console.WriteLine($"Tải thành công - statusCode {(int)response.StatusCode} {response.ReasonPhrase}");

                Console.WriteLine("Starting read data");

                // Đọc nội dung content trả về - ĐỌC CHUỖI NỘI DUNG
                string htmltext = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Nhận được {htmltext.Length} ký tự");
                Console.WriteLine();
                return htmltext;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
