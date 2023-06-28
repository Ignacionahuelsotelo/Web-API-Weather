using Microsoft.AspNetCore.Mvc;
using WeatherApi.DataTransferObjects;
using WeatherApi.Models;

namespace WeatherApi.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<Weather>> GetWeatherByCountryAndCity(int cityId, int countryId);
        Task<IEnumerable<Weather>> GetWeatherForNextFiveDaysByCity(int cityId, DateTime dateForWeather);
    }
}
