namespace WeatherApp.Service
{
    using System.Net.Http.Json;
    using System.Text.Json.Serialization;
    using Newtonsoft.Json;
    using static System.Net.WebRequestMethods;

    public class ApiService
    {
                public static string weatherapikey = "2785132fc5a79e85c2b0766fd4d3157b";
                public static async Task<WeatherInfo> GetWeatherByCoordinatesAsync(double latitude, double longtitude)
                {
                    try
                    {
                        var httpClient = new HttpClient();
                        var _uri = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}.9795&lon={longtitude}&units=metric&appid={weatherapikey}";
                        var _response = await httpClient.GetStringAsync(_uri);
                        var _weather = JsonConvert.DeserializeObject<WeatherInfo>(_response);
                        return _weather;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return null;
                    }
                }

                public static async Task<WeatherInfo> GetWeatherByCityAsync(string city)
                {
                    try
                    {
                        var httpClient = new HttpClient();
                        var _uri = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={weatherapikey}";
                        var _response = await httpClient.GetStringAsync(_uri);
                        var _weather = JsonConvert.DeserializeObject<WeatherInfo>(_response);
                        return _weather;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return null;
                    }
                }
    }
}
