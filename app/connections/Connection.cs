using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.app.models;
using WeatherApplication.app.views;

namespace WeatherApplication.app.connections
{
    public class Connection
    {
        public static async Task ConnectAsync(string location, string key, ShowInfo si, string lang)
        {
            try
            {
                // Connect to our API
                WebRequest request =
                    WebRequest.Create($"https://api.openweathermap.org/data/2.5/weather?q={location}&lang={lang}&units=metric&appid={key}");
                //Take response from OpenWeatherAPI
                request.Method = "POST";
                //Convert request to response
                WebResponse response = await request.GetResponseAsync();
                string answer = string.Empty;
                //Reading response
                using (Stream s = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(s))
                    {
                        answer = await sr.ReadToEndAsync();
                    }
                }
                //Closed response
                response.Close();

                //Используем метод DeserializeObject для того, чтобы не сохранять состояние объекта для последующего воссоздания
                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(answer);

                si.UpdateInfo(
                    si,
                    location,
                    weatherResponse.main.temp,
                    weatherResponse.weather[0].description,
                    weatherResponse.wind.speed,
                    weatherResponse.weather[0].icon
                    );
            }
            catch(Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(ex.Message);
            }
        }
    }
}
