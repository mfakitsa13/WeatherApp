using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Shared.Entities
{
    public class City
    {
        [Required(ErrorMessage = "This field is required")]
        public string? CityName { get; set; }
    }
}
