using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JMAPILibrary
{
    public class WeatherProcessor
    {


        public static async Task<WeatherModel> LoadWeatherModels(string callType, string key, string location, string aqi)
        {
            string url = $"http://api.weatherapi.com/v1/{callType}.json?key={key}&q={location}/&aqi={aqi}";

            using (HttpResponseMessage response = await APIHelper.APIClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    WeatherModel currentWeatherModel = await response.Content.ReadAsAsync<WeatherModel>();
                    return currentWeatherModel;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<WeatherModel> LoadWeatherModels(string callType, string key, string location, int days, string aqi, string alerts)
        {
            string url = $"http://api.weatherapi.com/v1/{callType}.json?key={key}&q={location}&days={days}&aqi={aqi}&alerts={alerts}";

            using (HttpResponseMessage response = await APIHelper.APIClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    WeatherModel currentWeatherModel = await response.Content.ReadAsAsync<WeatherModel>();
                    return currentWeatherModel;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
