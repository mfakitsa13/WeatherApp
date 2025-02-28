using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;
using WeatherApp.Data;
using WeatherApp.Service;
using WeatherApp.Shared.Entities;

namespace WeatherApp.Pages
{
    public partial class RealWeatherForecast : ComponentBase
    {
        private City city = new City();

        public WeatherInfo weatherInfo= new WeatherInfo();

        public RealWeatherForecast()
        {
            weatherInfo = null;
        }

        public DateTime Date { get; set; }
        public DateTime localTimeSunrise { get; set; }
        public DateTime localTimeSunset { get; set; }

        private bool isLoading = true;
        protected override async Task OnInitializedAsync()
        {  
            await Task.Delay(3000); 
            isLoading = false;
            await Task.Run(GetWeatherByCityAsync);
            StateHasChanged();
        }

        protected override async Task OnParametersSetAsync()
        {    
            await GetWeatherByCityAsync();
            StateHasChanged();
        }
         private async Task GetWeatherByCityAsync()
        {
           
            weatherInfo = await ApiService.GetWeatherByCityAsync(city.CityName);

            if (weatherInfo != null)
            {
                localTimeSunrise = DateTimeOffset.FromUnixTimeSeconds(weatherInfo.sys.sunrise).LocalDateTime;
                localTimeSunset = DateTimeOffset.FromUnixTimeSeconds(weatherInfo.sys.sunset).LocalDateTime;
            }

        }
    }
}
