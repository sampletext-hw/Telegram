using System.Collections.Generic;
using System.Linq;
using WebAPI.DataAccess;
using WebAPI.DataRepository;

namespace WebAPI.BusinessLogic
{
    public class WeatherForecastService
    {
        private readonly IEntityRepository<WeatherForecast> _weatherForecastRepository;

        public WeatherForecastService(IEntityRepository<WeatherForecast> weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public virtual List<WeatherForecast> GetAllForecasts()
        {
            var result = new List<WeatherForecast>();

            result = _weatherForecastRepository.GetAllQueryable().ToList();

            return result;
        }
    }
}