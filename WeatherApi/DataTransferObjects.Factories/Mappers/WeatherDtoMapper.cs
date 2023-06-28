using WeatherApi.DataTransferObjects.Factories.Dto;
using WeatherApi.Models;

namespace WeatherApi.DataTransferObjects.Factories.Mappers
{
    public class WeatherDtoMapper
    {
        public ReadWeatherDto MapEntityToDto(Weather weather,ReadWeatherDto dto)
        {
            dto.DayOfWeekName = weather.Date.ToString("dddd");
            dto.Date = weather.Date;
            dto.CityName = weather.CityName;
            dto.CountryName = weather.CountryName;
            if(dto.IsFarenheit)
            {
                dto.MinTemperature = ((weather.MinTemperature * 9) / 5) + 32;
                dto.MaxTemperature = ((weather.MaxTemperature * 9) / 5) + 32;
            }
            else
            {
                dto.MinTemperature = weather.MinTemperature;
                dto.MaxTemperature = weather.MaxTemperature;
            }

            return dto;
        }
    }
}
