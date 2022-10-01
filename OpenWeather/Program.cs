using System;
using Newtonsoft.Json.Linq;

namespace OpenWeather
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            Console.Write("Enter your API key:  ");
            var apiKey = Console.ReadLine();

            string city;
            do
            {
                Console.WriteLine();
                Console.Write("Enter the city:  ");
                city = Console.ReadLine();
                if (city == "") { break; }
                var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=imperial&appid={apiKey}";

                var response = client.GetStringAsync(url).Result;

                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();

                Console.WriteLine(formattedResponse);
                Console.WriteLine();
            } while (true);
        }
    }
}