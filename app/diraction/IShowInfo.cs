using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication.app.diraction
{
    internal interface IShowInfo
    {
        void UpdateInfo(string location, float temp, string[] description, float speed);
    }
}
