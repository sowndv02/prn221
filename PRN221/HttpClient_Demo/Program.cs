using System.Net.Http;

internal class Program
{
    // HttpC1ient is intended to be instantiated once per application
    static readonly HttpClient client = new HttpClient();
    private static async void Main(string[] args)
    {
        string uri = "http: //www. contoso.com/";
        // Call asynchronous network methods in a try/catch block to handle exceptions.
        try
        {
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch(HttpRequestException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}