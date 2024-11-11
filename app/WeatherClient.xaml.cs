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
        private string key = "";//PUT_YOUR_TOKEN_HERE
        private string location;
        private static string answer;

        public WeatherClient()
        {
            InitializeComponent();
            showInfo = new ShowInfo(labelInfo,
                labelTemp, 
                labelDescription, 
                labelWindSpeed);
        }

        private void BSearchClick(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            //if (string.IsNullOrWhiteSpace(TBoxAppKey.Text))
            //    error.AppendLine("Ключ введен некорректно");

            if (string.IsNullOrWhiteSpace(TBoxLocation.Text))
                error.AppendLine("Город введен некорректно");

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Ошибка работы программы", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            //key = TBoxAppKey.Text;
            location = TBoxLocation.Text;

            try
            {
                Connection.ConnectAsync(location, key, showInfo).Wait();
            }
            catch (Exception ex)//Add more exceptions
            {
                error.AppendLine(Convert.ToString(ex));
            }
        }

    }
}
