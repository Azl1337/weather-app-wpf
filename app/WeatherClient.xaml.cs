using System;
using System.Text;
using System.Windows;
using WeatherApplication.app.connections;
using WeatherApplication.app.views;

namespace WeatherApplication
{
    public partial class WeatherClient : Window
    {
        private readonly ShowInfo showInfo;
        private string key = "";//PUT_YOUR_TOKEN_HERE
        private string location;
        private string lang = "ru";//Change if you need another language. For example : English - en

        public WeatherClient()
        {
            InitializeComponent();
            showInfo = new ShowInfo(labelInfo,
                labelTemp, 
                labelDescription, 
                labelWindSpeed,
                imageWeaterIcon);
        }

        private void BSearchClick(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(TBoxLocation.Text))
                error.AppendLine("Город введен некорректно");

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Ошибка работы программы", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            location = TBoxLocation.Text;

            try
            {
                Connection.ConnectAsync(location, key, showInfo, lang).Wait(500);
            }
            catch (Exception ex)//Add more exceptions
            {
                error.AppendLine(Convert.ToString(ex));
            }
        }

        private void BExitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
