using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using tiniottest.core.Model;

namespace tiniottest.core
{
    class WeatherApi
    {
        
        private String API_KEY = "eb05f6219511c8637d3d7c10274031ed";
        private String API_URL = "https://api.openweathermap.org/data/2.5/weather?zip={0},us&APPID={1}&units=imperial";
        private String API_URL_CITY = "https://api.openweathermap.org/data/2.5/weather?q={0},us&APPID={1}&units=imperial";

        public Task<WeatherInfo> GetWeather(string zipCode)
        {
            return Task.Run<WeatherInfo>(async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    var responseString = string.Empty;
                    var requestUrl = String.Format(API_URL, zipCode, API_KEY);
                    ///httpClient.BaseAddress = new Uri( );
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        responseString = await httpClient.GetStringAsync(requestUrl);
                        JObject json = JObject.Parse(responseString);

                        var returnedObject = parseWeatherInfo(json);// JsonConvert.DeserializeObject<T>(responseString);
                        return returnedObject;
                    }
                    catch (Exception ex)
                    {
                        var mesg = ex.Message;
                        return null;
                    }
                }
            });
        }//End of Async method

        public Task<WeatherInfo> GetWeatherByCity(string city)
        {
            return Task.Run<WeatherInfo>(async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    var responseString = string.Empty;
                    var requestUrl = String.Format(API_URL_CITY, city, API_KEY);
                    ///httpClient.BaseAddress = new Uri( );
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        responseString = await httpClient.GetStringAsync(requestUrl);
                        JObject json = JObject.Parse(responseString);

                        var returnedObject = parseWeatherInfo(json);// JsonConvert.DeserializeObject<T>(responseString);
                        return returnedObject;
                    }
                    catch (Exception ex)
                    {
                        var mesg = ex.Message;
                        return null;
                    }
                }
            });
        }//E

        private WeatherInfo parseWeatherInfo(JObject jsonObject)
        {
            WeatherInfo result = new WeatherInfo();
            JArray weather = (JArray)jsonObject.SelectToken("weather");
            result.WeatherMain = (string)weather.First.SelectToken("main"); //.value = (string)signInName.SelectToken("value");
            result.WeatherDesc = (string)weather.First.SelectToken("description");
            result.IconString = (string)weather.First.SelectToken("icon");
            JToken main = jsonObject.SelectToken("main");
            result.CurrentTemp = (string)main.SelectToken("temp");

            result.City = (string)jsonObject.SelectToken("name");
            return result;
        }

    }
}

