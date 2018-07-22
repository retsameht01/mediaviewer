using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tiniottest.core.Model
{
    class WeatherInfo
    {
        public String IconString { get; set; }
        public String CurrentTemp { get; set; }
        public String City { get; set; }
        public String WeatherMain { get; set; }
        public String WeatherDesc { get; set; }
        public String WeatherDisplayText{get{
                String weather = "{0} F, {1}";
                return String.Format(weather, CurrentTemp, City);
        } }
    }
}
