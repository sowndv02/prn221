internal class Program
{
    private static async void Main(string[] args)
    {
        // synchronous: lập trình đơn luồng khi ứng dụng có nhiều task thực hiện theo thứ tự nào đó

        // asynchronous: Lập trình bất đồng bộ (đa luồng)
        // Task: Dùng biểu diễn tác vụ

        // Khai báo Task có 2 cách
        //Task t2 = new Task(Action); // () => {}
        Task t2 = Task2();

        // Task t3 = new Task(Action<Object>, Object); // (Object ob) => {}
        Task t3 = Task3();  

        // Khởi chạy Task. Nếu gọi 2 lần sẽ exception
        // t2.Start(); // Thread riêng
        // t3.Start(); // Thread riêng

        DoSomeThing(5, "T1", ConsoleColor.Red); // Thread riêng
        // Khi task chính ở Main kết thúc (T1) thì T2 hay T3 cũng kết thúc theo

        //t2.Wait(); // Đảm bảo T2 phải hoàn thành thì mới làm những task sau
        //t3.Wait();

        //Task.WaitAll(t2, t3); // Chờ tất cả các task được liệt kê chạy xong

        await t2;
        await t3;

        // async/await có giá trị trả về
        // Task<T>
        // Task<string> t1 = new Task<string>(Func<string>); // () => { return string; }
        
        Task t1 = Task1();  


        //Task<string> t0 = new Task<string>(Func<object, string>, object); // (object ob) => { return string; }
        
        Task t0 = Task0();

        t0.Start();
        t1.Start();

        ///Task.WaitAll(t0, t1);
        
        await t0;
        await t1;

        // var resultT0 =  t0.Result; // Đpcj kq từ t0
        // var resultT1 =  t1.Result; // Đọc kq từ t1

        Console.WriteLine("Press any key");
        Console.ReadKey();


        var task = GetWeb("https://youtube.com");

        var content = await task;
        Console.WriteLine(content);


    }


    static async Task<string> GetWeb(string url)
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        string content = await response.Content.ReadAsStringAsync();
        return content;
    }

    static async Task<object> Abc()
    {
        Task<Object> task = new Task<Object>(
            () =>
            {
                // Các tác vụ
                return new object();
            }
            );
        task.Start();

        var result = await task;
        return result;
    }

    static async Task<string> Task1()
    {
        Task<string> t1 = new Task<string>(
            () =>
            {
                DoSomeThing(10, "T1", ConsoleColor.Magenta);
                return "Return from T1";
            }
        );
        t1.Start ();
        var result = await t1;
        Console.WriteLine("Done t1");
        return result;
    }
    static async Task<string> Task0()
    {
        Task<string> t0 = new Task<string>(
            (Object ob) =>
            {
                string t = (string)ob;
                DoSomeThing(4, t, ConsoleColor.Yellow);
                return $"Return from {t}";
            }, "T0");
        t0.Start ();
        var result = await t0;
        Console.WriteLine("Done t0");
        return result;
    }

    static async Task Abc1()
    {
        Task task = new Task(() =>
        {
            // Các chỉ thị được thực hiện
        });
        task.Start();
        await task;
        // Các chỉ thị khác khi task thực hiện thành công

        await File.WriteAllTextAsync("1.txt", "sondv");

    }

    static async Task Task2()
    {
        Task t2 = new Task(
            () => { DoSomeThing(10, "T2", ConsoleColor.Yellow); }
        );
        t2.Start ();
        await t2; // Tại thời điểm này sẽ trả về task luôn
        
        // t2.Wait(); // Nếu để như này thì khi Task 2 done thì task 3 mới được chạy
        Console.WriteLine("T2 done");

    }

    static async Task Task3()
    {
        Task t3 = new Task(
            (Object ob) =>
            {
                string taskName = (string)ob;
                DoSomeThing(4, taskName, ConsoleColor.Blue);
            }, "T3"
        );

        t3.Start();
        await t3;

        // t3.Wait (); // 
        Console.WriteLine("T2 done");
    }

    static void DoSomeThing(int seconds, string msg, ConsoleColor color)
    {
        lock (Console.Out) // Khóa không cho phép truy cập console khi chưa hoàn thành task bên dưới
        {
            Console.ForegroundColor = color; // set màu console
            Console.WriteLine($"{msg,10} Start.....");
            Console.ResetColor(); // reset color console
        }


        // Thread.Sleep(seconds); // Dừng luồng đang chạy bao nhiêu milisecond
        for (int i = 0; i < seconds; i++)
        {
            lock(Console.Out) // Khóa không cho phép truy cập console khi chưa hoàn thành task bên dưới
            {
                Console.ForegroundColor = color; // set màu console
                Console.WriteLine($"{msg,10} {i,2}");
                Console.ResetColor(); // reset color console
            }

            
            Thread.Sleep(1000);
        }



        lock (Console.Out) // Khóa không cho phép truy cập console khi chưa hoàn thành task bên dưới
        {
            Console.ForegroundColor = color; // set màu console
            Console.WriteLine($"{msg,10} End.....");
            Console.ResetColor(); // reset color console
        }

        string a = "abc";
        lock(a) // Khóa biến a lại những thằng khác không được truy cập
        {
            // Code xử lý.....
            // Sau khi thực hiện xong ở đây thì biến a sẽ được mở khóa
        }
    }

}