using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Dependency_Injection
{
    // Phải có Microsoft.Extensions.Options
    public class ConfigInjectWithIOption
    {

        public static void Main(string[] args)
        {

            ConfigurationRoot configurationRoot;
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("appsettings.json");

            configurationRoot = (ConfigurationRoot)configurationBuilder.Build();


            //var cf1 = configurationRoot.GetSection("Option2").GetSection("key1").Value; // Test
            //var cf2 = configurationRoot.GetSection("Option2").GetSection("key2").Value; // 789
            //var cf3 = configurationRoot.GetSection("Option2").GetSection("key3").Value; // null, không tồn tại


            var sectionMyServiceOption = configurationRoot.GetSection("MyServiceOptions");



            var services = new ServiceCollection();
            services.AddSingleton<MyService>();

            var provider = services.BuildServiceProvider();
            var mySerivce = provider.GetService<MyService>();




            // Đăng ký là 1 cấu hình
            // Lúc này trong ServiceCollection chứa 2 hệ thống
            // 1. Là hệ thống chứa các Options 
            // -- Khi MyService được khởi tao thì trong hàm tọa có khai báo sử dụng
            // IOption<MyServiceOptions> thì hệ thống sẽ tìm kiếm có đối tượng Option nào
            // thì lấy ra và inject vào MyService


            //services.Configure<MyServiceOptions>(
            //    options => {
            //        options.data1 = "Xin chao cac ban";
            //        options.data2 = 2021;
            //    }
            //);
            services.AddOptions();
            services.Configure<MyServiceOptions>(sectionMyServiceOption); // Đọc từ file config
            mySerivce.PrintData();
        }

    }

    public class MyServiceOptions
    {
        public string data1 { get; set; }
        public int data2 { get; set; }
    }

    public class MyService
    {
        public string data1 { get; set; }
        public int data2 { get; set; }

        // Tham số khởi tạo là IOptions, các tham số khởi tạo khác nếu có khai báo như bình thường
        public MyService(IOptions<MyServiceOptions> options)
        {
            // Đọc được MyServiceOptions từ IOptions
            MyServiceOptions opts = options.Value;
            data1 = opts.data1;
            data2 = opts.data2;
        }
        public void PrintData() => Console.WriteLine($"{data1} / {data2}");
    }
}
