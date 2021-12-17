using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.DataRepository
{
    public class WeatherForecast
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(-20, 55)]
        public int TemperatureC { get; set; }

        [NotMapped]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [Required]
        [MaxLength(256)]
        public string Summary { get; set; }
    }
}