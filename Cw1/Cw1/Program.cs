using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
            try
            {
                var client = new HttpClient();
                var result = await client.GetAsync(url);
                //ThreadPool() - trzyma gotowe do dzialania watki 

                var list = new List<string>();
                var zbior = new HashSet<string>();
                var slownik = new Dictionary<string, int>();
                if (result.IsSuccessStatusCode)
                {
                    string html = await result.Content.ReadAsStringAsync();
                    var regex = new Regex("[a-z]+[a-z0-9]*@[a-z.]+");
                    var matches = regex.Matches(html);
                    foreach (var m in matches)
                    {
                        Console.WriteLine(m);
                    }
                }
            }
            catch (Exception ex)
            {
                string blad = string.Format("Wystapil blad {0}", ex.ToString());
                Console.WriteLine($"Wystapil blad: {ex.ToString()}");
            }

        }


    }
}