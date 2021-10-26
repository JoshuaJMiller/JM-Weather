using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMAPILibrary
{
    public class WeatherModel
    {
        public CurrentModel Current { get; set; }
        public LocationModel Location { get; set; }
        public ForecastModel Forecast { get; set; }
    }
}
