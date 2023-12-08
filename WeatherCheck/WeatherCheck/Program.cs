using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace WeatherCheck
{
    internal class Program
    {
        public class APIInfo
        {
            public string day { get; set; }
            public string temperature { get; set; }
            public string wind { get; set; }
            public string description { get; set; }
            public List<forecast> forecast { get; set; }
        }
        public class forecast
        {
            public string day { get; set; }
            public string temperature { get; set; }
            public string wind { get; set; }
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("1-İstanbul  2-İzmir  3-Ankara");
            string secenek = Console.ReadLine();
            switch (secenek)
            {
                case "1":
                    await Istanbul();
                    break;
                case "2":
                    await Izmir();
                    break;
                case "3":
                    await Ankara();
                    break;
            }

        }
        static async Task Istanbul()
        {
            string api_istanbul = "https://goweather.herokuapp.com/weather/istanbul";



            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(api_istanbul);

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    APIInfo istanbul = JsonConvert.DeserializeObject<APIInfo>(jsonContent);

                    Console.WriteLine("İstanbul için 3 Günlük Hava Durumu:");
                    foreach (var forecast in istanbul.forecast)
                    {
                        Console.WriteLine($"  {forecast.day}: {forecast.temperature}, Rüzgar: {forecast.wind}");
                    }
                    Console.WriteLine($"  Bugünkü Durum: {istanbul.description}");
                    Console.ReadLine();

                }
                else
                {
                    Console.WriteLine($"Hata: {response.StatusCode}");
                    Console.ReadLine();
                }
            }
        }
        static async Task Izmir()
        {
            string api_izmir = "https://goweather.herokuapp.com/weather/izmir";



            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(api_izmir);

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    APIInfo izmir = JsonConvert.DeserializeObject<APIInfo>(jsonContent);

                    Console.WriteLine("İzmir için 3 Günlük Hava Durumu:");
                    foreach (var forecast in izmir.forecast)
                    {
                        Console.WriteLine($"  {forecast.day}: {forecast.temperature}, Rüzgar: {forecast.wind}");
                    }
                    Console.WriteLine($"  Bugünkü Durum: {izmir.description}");
                    Console.ReadLine();

                }
                else
                {
                    Console.WriteLine($"Hata: {response.StatusCode}");
                    Console.ReadLine();
                }
            }

        }
        static async Task Ankara()
        {
            string api_ankara = "https://goweather.herokuapp.com/weather/ankara";



            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(api_ankara);

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    APIInfo ankara = JsonConvert.DeserializeObject<APIInfo>(jsonContent);

                    Console.WriteLine("Ankara için 3 Günlük Hava Durumu:");
                    foreach (var forecast in ankara.forecast)
                    {
                        Console.WriteLine($"  {forecast.day}: {forecast.temperature}, Rüzgar: {forecast.wind}");
                    }
                    Console.WriteLine($"  Bugünkü Durum: {ankara.description}");
                    Console.ReadLine();

                }
                else
                {
                    Console.WriteLine($"Hata: {response.StatusCode}");
                    Console.ReadLine();
                }
            }

        }
    }
}
