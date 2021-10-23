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
        

        public static async Task<WeatherModel> LoadWeatherModels()
        {
            string url = "http://api.weatherapi.com/v1/current.json?key=efd1bc2dfe4c4a42a9c183606213108&q=91355&aqi=no";


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

            //public static async Task<ConditionModel> LoadCurrentWeatherCondition()
            //{
            //    string url = "http://api.weatherapi.com/v1/current.json?key=efd1bc2dfe4c4a42a9c183606213108&q=91355&aqi=no";


            //    using (HttpResponseMessage response = await APIHelper.APIClient.GetAsync(url))
            //    {
            //        if (response.IsSuccessStatusCode)
            //        {
            //            WeatherModel currentWeatherModel = await response.Content.ReadAsAsync<WeatherModel>();

            //            return currentWeatherModel.Current.Condition;
            //        }
            //        else
            //        {
            //            throw new Exception(response.ReasonPhrase);
            //        }
            //    }
            //}

            //public static async Task<CurrentModel> LoadCurrentWeather()
            //{
            //    string url = "http://api.weatherapi.com/v1/current.json?key=efd1bc2dfe4c4a42a9c183606213108&q=91355&aqi=no";


            //    using (HttpResponseMessage response = await APIHelper.APIClient.GetAsync(url))
            //    {
            //        if (response.IsSuccessStatusCode)
            //        {
            //            WeatherModel currentWeatherCurrentModel = await response.Content.ReadAsAsync<WeatherModel>();

            //            return currentWeatherCurrentModel.Current;
            //        }
            //        else
            //        {
            //            throw new Exception(response.ReasonPhrase);
            //        }
            //    }
            //}
        }
    }
}
