using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ParkWeather
    {
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }
        public string WeatherImage { get; set; }
        public string WeatherReccomendation { get; set; }
        public string TempReccomendation { get; set; }


        public ParkWeather()
        {
            if (Forecast == "rain")
            {
                WeatherImage = "rain.png";
                WeatherReccomendation = "Better pack your rain gear and wear waterproof shoes!";
            }
            else if (Forecast == "cloudy")
            {
                WeatherImage = "cloudy.png";
                WeatherReccomendation = "";
            }
            else if (Forecast == "partly cloudy")
            {
                WeatherImage = "partlyCloudy.png";
                WeatherReccomendation = "";
            }
            else if (Forecast == "snow")
            {
                WeatherImage = "snow.png";
                WeatherReccomendation = "Be sure to bring snowshoes";
            }
            else if (Forecast == "sunny")
            {
                WeatherImage = "sunny.png";
                WeatherReccomendation = "Pack sunscreen";
            }
            else if (Forecast == "thunderstorms")
            {
                WeatherImage = "thunderstorms.png";
                WeatherReccomendation = "Seek shelter. Avoid Exposed Ridges";
            }







        }

    }

}


//if (@Model.Weather[0].Forecast == "rain")
//    {
//        weatherImg0 = "rain.png";
//        weatherMsg0 = "Better pack your rain gear and wear waterproof shoes!";
//    }
//    else if (@Model.Weather[0].Forecast == "cloudy")
//    {
//        weatherImg0 = "cloudy.png";
//    }
//    else if (@Model.Weather[0].Forecast == "partly cloudy")
//    {
//        weatherImg0 = "partlyCloudy.png";
//    }
//    else if (@Model.Weather[0].Forecast == "snow")
//    {
//        weatherImg0 = "snow.png";
//        weatherMsg0 = "Better pack your snowshoes!";
//    }
//    else if (@Model.Weather[0].Forecast == "sunny")
//    {
//        weatherImg0 = "sunny.png";
//        weatherMsg0 = "Bring sunscreen";
//    }
//    else if (@Model.Weather[0].Forecast == "thunderstorms")
//    {
//        weatherImg0 = "thunderstorms.png";
//        weatherMsg0 = "Seek shelter! Avoid hking on exposed ridges!";
//    }