using WeatherApi.DataTransferObjects.Factories.Dto;
using WeatherApi.DataTransferObjects.Factories.Mappers;
using WeatherApi.Models;

namespace WeatherApi.DataTransferObjects.Factories
{
    public class WeatherDtoFactory
    {
        private readonly WeatherDtoMapper mapper = new WeatherDtoMapper();
        public IEnumerable<IReadWeatherDto> CreateReadWeatherDto(IEnumerable<Weather> entity, bool isFarenheit)
        {
            var dtos = new List<ReadWeatherDto>();

            foreach (var weather in entity)
            {
                var dto = new ReadWeatherDto();
                dto.IsFarenheit = isFarenheit;
                dtos.Add(mapper.MapEntityToDto(weather, dto));

            }

            return dtos;
        }
    }
}
