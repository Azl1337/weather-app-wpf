using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using WeatherApplication.app.connections;
using WeatherApplication.app.views;


namespace WeatherApplication
{
    public partial class WeatherClient : Window
    {
        private readonly ShowInfo showInfo;
        public WeatherClient()
        {
            InitializeComponent();
            showInfo = new ShowInfo(labelInfo,
                labelTemp, 
                labelDescription, 
                labelWindSpeed);
        }

        private string key;
        private string location;
        private static string answer;

        private void BSearchClick(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(TBoxAppKey.Text))
                error.AppendLine("Ключ введен некорректно");

            if (string.IsNullOrWhiteSpace(TBoxLocation.Text))
                error.AppendLine("Город введен некорректно");

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Ошибка работы программы", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            key = TBoxAppKey.Text;
            location = TBoxLocation.Text;

            try
            {
                Connection.ConnectAsync(location, key).Wait();
            }
            catch (Exception ex)
            {
                error.AppendLine(Convert.ToString(ex));
            }
        }

        //Данные классы реализованы как способ обращения к запросам самого API
        public class WeatherResponse
        {
            public TemperatureInfo main { get; set; }
            public Description[] weather { get; set; }
            public WindSpeedInfo wind { get; set; }

        }

        //Запрос main.temp - дает нам возможность получить данные о температуре
        public class TemperatureInfo
        {
            public float temp { get; set; }
            public float temp_min {  get; set; }
            public float temp_max {  get; set; }
        }

        //Запрос weather[].description - дает нам возможность получить данные об описании погоды
        public class Description
        {
            public string description;
        }

        //Запрос wind.speed - дает нам возможность получить данные о скорости ветра
        public class WindSpeedInfo
        {
            public double speed { get; set; }
        }

    }
}
