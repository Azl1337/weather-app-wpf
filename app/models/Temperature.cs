using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication.app.models
{
    //Запрос main.temp - дает нам возможность получить данные о температуре
    internal class Temperature
    {
        public float temp;
        public float feels_like;
        public float temp_min;
        public float temp_max;
        public int pressure;
        public int sea_level;
        public int grnd_level;
        public int humidity;
        public float temp_kf;
    }
}
