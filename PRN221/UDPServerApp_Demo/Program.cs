using System.Net;
using System.Net.Sockets;

internal class Program
{
    const int listenePort = 11000;
    const string host = "127.0.0.1";
    private static void Main(string[] args)
    {
        Thread thread = new Thread(new ThreadStart(StartListener));
        thread.Start(); 
    }   

    private static void StartListener()
    {
        string message;
        UdpClient listener = new UdpClient(listenePort);
        IPAddress address = IPAddress.Parse(host);
        IPEndPoint remoteEndpoint = new IPEndPoint(address, listenePort);
        Console.Title = "UDP Server";
        Console.WriteLine(new string('*', 40));
        try
        {
            while (true)
            {
                Console.WriteLine("Waiting for broadcast");
                byte[] bytes = listener.Receive(ref remoteEndpoint);
                message = System.Text.Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                Console.WriteLine($"Received broadcast from {remoteEndpoint}:{message}");
            }
        }catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            listener.Close();
        }
    }
}