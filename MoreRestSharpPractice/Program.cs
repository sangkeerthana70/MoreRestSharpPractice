using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreRestSharpPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var client = new RestClient("https://api.openweathermap.org/data/2.5");*/
            var client = new RestClient("https://samples.openweathermap.org/data/2.5");
                  // create a new request
            var request = new RestRequest("/weather?zip=02184,us&appid=");

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string
            Console.WriteLine("Content: " + content);

            // parses a JSON array from a string using JArray.Parse(String).
            //JArray a = JArray.Parse(content);

            //Console.WriteLine("String a: " + a);

            //Deserialize will convert the raw string into Json format
            // Take the Json and convert it into a Csharp Object
            Weather w = JsonConvert.DeserializeObject<Weather>(content);
            Console.WriteLine("name:" + w.name);
            //access the Dictionary through its key:value
            Console.WriteLine("temp:" + w.main["temp"]);
            Console.WriteLine("pressure:" + w.main["pressure"]);
            Console.WriteLine("humidity:" + w.main["humidity"]);
            Console.WriteLine("visibility:" + w.visibility);
            Console.WriteLine("wind speed:" + w.wind["speed"]);
            Console.WriteLine("description:" + w.weather[0]["description"]);

            float temp = w.main["temp"];



        }
    }
}
