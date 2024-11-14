using System.IO;

namespace WeatherApplication.app.models
{
    //Запрос weather[].description - дает нам возможность получить данные об описании погоды
    internal class Weather
    {
        public string main;
        public string description;
        public string icon;
    }
}
