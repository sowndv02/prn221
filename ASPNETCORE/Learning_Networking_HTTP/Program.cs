using System.Net;
using System.Net.NetworkInformation;

internal class Program
{
    //private static void Main(string[] args)
    //{
    //    // Phân tích URI
    //    //string url = "https://xuanthulab.net/lap-trinh/csharp/?page=3#acff";
    //    //var uri = new Uri(url);
    //    //var uritype = typeof(Uri);
    //    //uritype.GetProperties().ToList().ForEach(property => {
    //    //    Console.WriteLine($"{property.Name,15} {property.GetValue(uri)}");
    //    //});
    //    //Console.WriteLine($"Segments: {string.Join(",", uri.Segments)}");
    //    // KET QUA

    //    //    AbsolutePath /lap-trinh/csharp/
    //    //     AbsoluteUri https://xuanthulab.net/lap-trinh/csharp/?page=3#acff
    //    //       LocalPath /lap-trinh/csharp/
    //    //       Authority xuanthulab.net
    //    //    HostNameType Dns
    //    //   IsDefaultPort True
    //    //          IsFile False
    //    //      IsLoopback False
    //    //    PathAndQuery /lap-trinh/csharp/?page=3
    //    //        Segments System.String[]
    //    //           IsUnc False
    //    //            Host xuanthulab.net
    //    //            Port 443
    //    //           Query ?page=3
    //    //        Fragment #acff
    //    //          Scheme https
    //    //  OriginalString https://xuanthulab.net/lap-trinh/csharp/?page=3#acff
    //    //     DnsSafeHost xuanthulab.net
    //    //         IdnHost xuanthulab.net
    //    //   IsAbsoluteUri True
    //    //     UserEscaped False
    //    //        UserInfo
    //    //  Segments: /,lap-trinh/,csharp/


    //    // Get host name Dns và lớp IPHostEntry

    //    var hostName = Dns.GetHostName();
    //    Console.WriteLine(hostName);

    //    string url = "https://www.bootstrapcdn.com/";
    //    var uri = new Uri(url);
    //    var hostEntry = Dns.GetHostEntry(uri.Host);
    //    Console.WriteLine($"Host {uri.Host} có các IP");
    //    hostEntry.AddressList.ToList().ForEach(ip => Console.WriteLine(ip));


    //    // Host www.bootstrapcdn.com có các IP
    //    // 54.84.220.80
    //    // 52.203.100.2
    //    // 54.226.184.31
    //    // 34.235.106.23
    //    // 54.159.163.191
    //    // 54.164.152.149
    //    // 34.196.72.78
    //    // 34.195.37.70

    //    // Ping
    //    var ping = new Ping();
    //    var pingReply = ping.Send("google.com.vn");
    //    Console.WriteLine(pingReply.Status);
    //    if (pingReply.Status == IPStatus.Success)
    //    {
    //        Console.WriteLine(pingReply.RoundtripTime);
    //        Console.WriteLine(pingReply.Address);
    //    }

    //    // Success
    //    // 322
    //    // 172.217.24.195
    //}
}