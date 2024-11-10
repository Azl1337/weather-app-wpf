using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WeatherApplication.WeatherClient;
using System.Windows.Shapes;
using System.Windows.Controls;
using WeatherApplication.app.diraction;

namespace WeatherApplication.app.views
{
    internal class ShowInfo : IShowInfo
    {
        private readonly Label _labelInfo;
        private readonly Label _labelTemp;
        private readonly Label _labelDescription;
        private readonly Label _labelWindSpeed;
        public ShowInfo(Label labelInfo, Label labelTemp, Label labelDescription, Label labelWindSpeed)
        {
            _labelInfo = labelInfo;
            _labelTemp = labelTemp;
            _labelDescription = labelDescription;
            _labelWindSpeed = labelWindSpeed;
        }

        public void UpdateInfo(string location, float temp, string[] description, float speed)
        {
            _labelInfo.Content = $"Информация о погоде в {location}";
            _labelTemp.Content = temp + " °C";
            _labelDescription.Content = description;
            _labelWindSpeed.Content = speed + " м/с";

            //_labelInfo.Content = $"Информация о погоде в {location}";
            //_labelTemp.Content = weatherResponse.main.temp + " °C";
            //_labelDescription.Content = weatherResponse.weather[0].description;
            //_labelWindSpeed.Content = weatherResponse.wind.speed + " м/с";
        }
    }
}
