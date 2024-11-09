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


namespace WeatherApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string appKey;
        public string location;

        private void BSearchClick(object sender, RoutedEventArgs e)
        {
            //Проверка на введение данных
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

            //При успешной проверке, введение переменных хранящих введенные данные
            appKey = TBoxAppKey.Text;
            location = TBoxLocation.Text;

            //Ссылка-запрос на получение данных о погоде в определенном городе
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={location}&units=metric&appid={appKey}";
            //для того, чтобы программа выдавала нам значение температуры в Фаренгейтах надо изменить units=metric => units=imperial

            //Объект запроса
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            //Считываем все данные с объекста httpWebRequest
            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            //Используем метод DeserializeObject для того, чтобы не сохранять состояние объекта для последующего воссоздания
            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

            //Вывод информации на экран
            LInfo.Content = $"Информация о погоде в {location}";

            LTemp.Content = weatherResponse.main.temp + " °C";
            LDescription.Content = weatherResponse.weather[0].description;
            LWindSpeed.Content = weatherResponse.wind.speed + " м/с";
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
