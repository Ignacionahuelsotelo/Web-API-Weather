using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherApi.Context;
using WeatherApi.DataTransferObjects;
using WeatherApi.Models;

namespace WeatherApi.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly AplicattionDbContext _context;

        public WeatherService(AplicattionDbContext context) 
        { 
            _context = context;
        
        }

        public async Task<IEnumerable<Weather>?> GetWeatherByCountryAndCity(int cityId, int countryId)
        {
            if (_context.Weather == null)
            {
                return null;
            }

            IEnumerable<Weather> result = await _context.Weather
                .Where(f => f.CountryId == countryId && f.CityId == cityId)
                .ToListAsync();

            if(!result.Any())
            {
                return null;
            }

            return result;
        }

        public async Task<IEnumerable<Weather>> GetWeatherForNextFiveDaysByCity(int cityId, DateTime dateForWeather)
        {
            if (_context.Weather == null)
            {
                return null;
            }

            
            DateTime dateWithFiveDaysAdded = GetDateAddingFiveDays(dateForWeather);

            IEnumerable<Weather> result= await _context.Weather
                .Where(f => f.CityId == cityId 
                && f.Date.Year >= dateForWeather.Year 
                && f.Date.Month >= dateForWeather.Month 
                && f.Date.Day >= dateForWeather.Day
                && f.Date.Year <= dateWithFiveDaysAdded.Year 
                && f.Date.Month <= dateWithFiveDaysAdded.Month 
                && f.Date.Day <= dateWithFiveDaysAdded.Day
                
                )
                .OrderBy(f => f.Date)
                .Take(5)
                .ToListAsync();

            if(!result.Any()) { return null; }


            return result;
        }

        private DateTime GetDateAddingFiveDays(DateTime date)
        {
            DateTime newDate  = date.AddDays(5);
            DateTime ret = new DateTime(newDate.Year, newDate.Month, newDate.Day);
            
            return ret;

        }


    }
}
