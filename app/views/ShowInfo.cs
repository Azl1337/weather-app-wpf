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
    public class ShowInfo 
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

        public static void UpdateInfo(ShowInfo si,string location, float temp, string description, float speed)
        {
            si._labelInfo.Content = $"Информация о погоде в {location}";
            si._labelTemp.Content = temp + " °C";
            si._labelDescription.Content = description;
            si._labelWindSpeed.Content = speed + " м/с";
        }
    }
}
