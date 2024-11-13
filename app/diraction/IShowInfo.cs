using WeatherApplication.app.views;

namespace WeatherApplication.app.diraction
{
    internal interface IShowInfo
    {
        void UpdateInfo(ShowInfo si, string location, float temp, string weather, float speed);
    }
}
