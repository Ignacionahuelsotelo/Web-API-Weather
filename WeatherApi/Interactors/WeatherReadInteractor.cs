using Microsoft.AspNetCore.Mvc;
using WeatherApi.DataTransferObjects;
using WeatherApi.DataTransferObjects.Factories;
using WeatherApi.Models;
using WeatherApi.Services;

namespace WeatherApi.Interactors
{
    public class WeatherReadInteractor
    {
        private readonly IWeatherService _weatherService;
        private readonly WeatherDtoFactory _weatherDtoFactory;

        public WeatherReadInteractor(IWeatherService weatherService, WeatherDtoFactory weatherDtoFactory)
        {
            _weatherService = weatherService;
            _weatherDtoFactory = weatherDtoFactory;
        }

        public async Task<IEnumerable<IReadWeatherDto>> GetWeatherByCountryAndCity(int cityId,int countryId, bool isFarenheit)
        {
            var weatherListByCountryAndCity = await _weatherService.GetWeatherByCountryAndCity(cityId, countryId);

            if (weatherListByCountryAndCity == null)
            {
                return null; 
            }
            
            var result = _weatherDtoFactory.CreateReadWeatherDto(weatherListByCountryAndCity, isFarenheit);

            return result;
        }

        public async Task<IEnumerable<IReadWeatherDto>> GetWeatherForNextFiveDaysByCity(int cityId, DateTime dateForWeather, bool isFarenheit)
        {
            var weatherListByCityForFiveDays = await _weatherService.GetWeatherForNextFiveDaysByCity(cityId, dateForWeather);
            
            if (weatherListByCityForFiveDays == null)
            {
                return null;
            }

            var result = _weatherDtoFactory.CreateReadWeatherDto(weatherListByCityForFiveDays, isFarenheit);

            return result;
        }

    }
}
