using System.Net.Http;
using System.Threading.Tasks;
using static System.Console;

namespace AsyncConsole
{
    class Program
    {
        public static async Task Main(string[] args) 
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://444.hu/");
            WriteLine($"444's home page has {response.Content.Headers.ContentLength:N0} bytes.");
        }
    }
}