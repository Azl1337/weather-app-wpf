using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication.app.models
{
    //Данные классы реализованы как способ обращения к запросам самого API
    internal class WeatherResponse
    {
        public Temperature main;
        public Weather[] weather;
        public Wind wind;
    }
}
