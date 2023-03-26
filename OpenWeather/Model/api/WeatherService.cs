using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace OpenWeather.Model.api
{
    public class WeatherService
    {
        private static readonly string URL_BASE = "https://api.openweathermap.org/data/2.5/";
        private static readonly string APP_ID = "";//Your API KEY
        private static readonly string IMG_URL_BASE_START = "https://openweathermap.org/img/wn/";
        private static readonly string IMG_URL_BASE_END = "@2x.png";

        public static async Task<WeatherOneDayResponse> CheckOneDayWeather(string city)
        {
            WeatherOneDayResponse weatherResponse = new WeatherOneDayResponse();

            using (var httpClient = new HttpClient())
            {

                HttpRequestMessage request;
                HttpResponseMessage response;
                try
                {
                    string url = string.Format("{0}weather?q={1}&appid={2}&lang=es&units=metric", URL_BASE, city, APP_ID);

                    request = new HttpRequestMessage(HttpMethod.Get, url);
                    response = await httpClient.SendAsync(request);

                    if (response != null)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string json = await response.Content.ReadAsStringAsync();
                            weatherResponse = JsonConvert.DeserializeObject<WeatherOneDayResponse>(json);
                        }
                        else
                        {
                            Console.WriteLine(String.Format("Error: {0} - {1}",
                            (int)response.StatusCode, response.StatusCode));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se puede obtener respuesta del servicio web");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
                return weatherResponse;
            }
        }

        public static async Task<WeatherFiveDaysResponse> CheckFiveDaysWeather(string city)
        {
            WeatherFiveDaysResponse weatherResponse = new WeatherFiveDaysResponse();

            using (var httpClient = new HttpClient())
            {

                HttpRequestMessage request;
                HttpResponseMessage response;
                try
                {
                    string url = string.Format("{0}forecast?q={1}&appid={2}&lang=es&units=metric", URL_BASE, city, APP_ID);

                    request = new HttpRequestMessage(HttpMethod.Get, url);
                    response = await httpClient.SendAsync(request);

                    if (response != null)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string json = await response.Content.ReadAsStringAsync();
                            weatherResponse = JsonConvert.DeserializeObject<WeatherFiveDaysResponse>(json);
                        }
                        else
                        {
                            Console.WriteLine(String.Format("Error: {0} - {1}",
                            (int)response.StatusCode, response.StatusCode));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se puede obtener respuesta del servicio web");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
                return weatherResponse;
            }
        }
        public static BitmapImage GetBitmapImage(string icon)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(IMG_URL_BASE_START + icon + IMG_URL_BASE_END);
            bitmap.EndInit();
            return bitmap;
        }
    }
}
