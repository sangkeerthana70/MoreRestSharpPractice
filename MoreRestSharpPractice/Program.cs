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
            var client = new RestClient("https://samples.openweathermap.org/data/2.5");

            // create a new request
            var request = new RestRequest("/weather?zip=02093,us&appid=b6907d289e10d714a6e88b30761fae22");

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string
            Console.WriteLine("Content : " + content);

            // parses a JSON array from a string using JArray.Parse(String).
            //JArray a = JArray.Parse(content);

            //Console.WriteLine("String a: " + a);


            //Deserialize will convert the raw string into Json format
            var output = JsonConvert.DeserializeObject(content);
            Console.WriteLine("Output: " + output);

            
        }
    }
}
