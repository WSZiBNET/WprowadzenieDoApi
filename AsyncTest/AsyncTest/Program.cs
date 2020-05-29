using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AsyncTest
{
    class Program
    {
        static void Main(string[] args)
        {
            GetGWB();
            Console.WriteLine("Hello world");
            Console.ReadKey();
        }

        public static async Task GetGWB()
        {
            HttpClient hc = new HttpClient();
            await hc.GetAsync("http://geekswithblogs.net/Default.aspx");
            Console.WriteLine("Pobrałem zawartość");
        }

    }
}
