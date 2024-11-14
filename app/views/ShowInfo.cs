using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WeatherApplication.app.diraction;
using WeatherApplication.app.models;

namespace WeatherApplication.app.views
{
    public class ShowInfo
    {
        private readonly Label _labelInfo;
        private readonly Label _labelTemp;
        private readonly Label _labelDescription;
        private readonly Label _labelWindSpeed;
        private readonly Image _imageWeatherIcon;
        public ShowInfo(Label labelInfo, Label labelTemp, Label labelDescription, Label labelWindSpeed, Image iconWeather)
        {
            _labelInfo = labelInfo;
            _labelTemp = labelTemp;
            _labelDescription = labelDescription;
            _labelWindSpeed = labelWindSpeed;
            _imageWeatherIcon = iconWeather;
        }

        public void UpdateInfo(ShowInfo si,string location, float temp, string weather, float speed, string icon)
        {
            si._labelInfo.Content = $"Информация о погоде в {location}";
            si._labelTemp.Content = temp + " °C";
            si._labelDescription.Content = weather;
            si._labelWindSpeed.Content = speed + " м/с";
            string _iconPath = "/WeatherApplication;component/resources/weatherIcons/" + icon.Trim() + ".png";
            si._imageWeatherIcon.Source = new BitmapImage(new Uri(_iconPath, UriKind.RelativeOrAbsolute));
        }
    }
}
