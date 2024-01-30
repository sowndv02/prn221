using System.Net;
using System.Net.Sockets;

internal class Program
{
    private static void Main(string[] args)
    {
        string host = "127.0.0.1";
        // Set the TcpListener on port 13000
        int port = 13000;
        ExecuteServer(host, port);
    }
    static void ProcessMessage(object param)
    {
        string data;
        int count;
        try
        {
            TcpClient client = param as TcpClient;
            // Buffer for reading dat
            Byte[] bytes = new Byte[256];
            // Get a stream object for reading and writing
            NetworkStream stream = client.GetStream();
            // Loop to receive all the data sent by the client
            while((count = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                // Translate data bytes to ASCII sring
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, count);
                Console.WriteLine($"Received: {data} at {DateTime.Now:t}");
                // Process the data sent by the client
                data = $"{data.ToUpper()}";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                // Send back a response
                stream.Write(msg, 0, msg.Length);
                Console.WriteLine($"Sent: {data}");
            }
            //Shutdown and end connection
            client.Close();
        }catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Waiting message.....");
        }
        
    }
    static void ExecuteServer(string host, int port)
    {
        int count = 0;
        TcpListener server = null;
        try
        {
            Console.Title = "Server Application";
            IPAddress localAddr = IPAddress.Parse(host);
            server = new TcpListener(localAddr, port);
            // Start listening for client requests.
            server.Start();
            Console.WriteLine(new string('*', 40));
            Console.WriteLine("Waiting for a connection....");
            // Enter the listening loop
            while(true)
            {
                // Perform  a blocking call to accept requests
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine($"Number of client conected: {++ count}");
                Console.WriteLine(new string('*', 40));
                // Create a thread to receive and send message
                Thread thread = new Thread(new ParameterizedThreadStart(ProcessMessage));
                thread.Start(client);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);  
        }finally 
        { 
            server.Stop();
            Console.WriteLine("Server stopped. Pres any key to exit!");
        }
        Console.ReadLine();
    }
}