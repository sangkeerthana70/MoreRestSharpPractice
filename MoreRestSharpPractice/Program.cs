using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreRestSharpPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://api.openweathermap.org/data/2.5");
            //var client = new RestClient("https://samples.openweathermap.org/data/2.5");
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
            

            string name = w.name;
            
            float temp = w.main["temp"];
            float pressure = w.main["pressure"];
            float humidity = w.main["humidity"];
            int visibility = w.visibility;
            float speed = w.wind["speed"];
            string description = w.weather[0]["description"];

            Console.WriteLine("name:" + name);
            //access the Dictionary through its key:value
            Console.WriteLine("temp:" + temp);
            Console.WriteLine("pressure:" + pressure);
            Console.WriteLine("humidity:" + humidity);
            Console.WriteLine("visibility:" + visibility);
            Console.WriteLine("wind speed:" + speed);
            Console.WriteLine("description:" + description);

            var connstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MoreRestSharpPractice;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();
                SqlCommand insCommand = new SqlCommand("INSERT INTO [Weather] (location, temp, tempF, tempC, humidity, visibility, pressure, wind, description) VALUES(@location, @temp, @tempF, @tempC, @humidity, @visibility, @pressure, @wind, @description)", connection);
                
                insCommand.Parameters.AddWithValue("@location", name);
                insCommand.Parameters.AddWithValue("@temp", temp);
                insCommand.Parameters.AddWithValue("@tempF", temp);
                insCommand.Parameters.AddWithValue("@tempC", temp);
                insCommand.Parameters.AddWithValue("@humidity", humidity);
                insCommand.Parameters.AddWithValue("@visibility", visibility);
                insCommand.Parameters.AddWithValue("@pressure", pressure);
                insCommand.Parameters.AddWithValue("@wind", speed);
                insCommand.Parameters.AddWithValue("@description", description);

                insCommand.ExecuteNonQuery();
                Console.WriteLine("DB updated");
                connection.Close();
            }
            






        }
    }
}
