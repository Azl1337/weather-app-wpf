using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace WeatherApplication.app.connection
{
    public class Connection
    {
        public static async Task ConnectAsync()
        {
            // Connect to our API
            WebRequest request = 
                WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?q=London&units=metric&appid=7244df743a266298bb814c8150e0fb65");
            //Take response from OpenWeatherAPI
            request.Method = "POST";
            //Convert request to response
            WebResponse response = await request.GetResponseAsync();
            //Reading response
            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    string answer = await sr.ReadToEndAsync();
                }
            }
            //Closed response
            response.Close();
        }
    }
}
