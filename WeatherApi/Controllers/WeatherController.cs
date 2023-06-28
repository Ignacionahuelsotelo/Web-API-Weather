using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherApi.Context;
using WeatherApi.DataTransferObjects;
using WeatherApi.Interactors;
using WeatherApi.Models;
using WeatherApi.Services;

namespace WeatherApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherReadInteractor _weatherReadInteractor;

        public WeatherController(WeatherReadInteractor weatherReadInteractor)
        {
            _weatherReadInteractor = weatherReadInteractor;
        }

        
        [HttpGet("weather-by-country-and-city/{country-id}/{city-id}")]
        public async Task<ActionResult<IEnumerable<IReadWeatherDto>>> GetWeatherByCountryAndCity(
            [FromRoute(Name = "country-id")] int countryId,
            [FromRoute(Name = "city-id")] int cityId,
            [FromQuery(Name = "optional-is-farenheit")] bool isFarenheit
            )
        {
            var result = await _weatherReadInteractor.GetWeatherByCountryAndCity(cityId, countryId, isFarenheit);

            if(result == null)
            {
                return BadRequest("No se encontraron registros con los parametros enviados");
            }

            return Ok(result); 
        }

        
        [HttpGet("weather-for-next-five-days-by-city/{city-id}/{date-for-weather}")]
        public async Task<ActionResult<IEnumerable<IReadWeatherDto>>> GetWeatherForNextFiveDaysByCity(
            [FromRoute(Name = "city-id")] int cityId,
            [FromRoute(Name = "date-for-weather")] DateTime dateForWeather,
            [FromQuery(Name = "optional-is-farenheit")] bool isFarenheit)
        {
            var result = await _weatherReadInteractor.GetWeatherForNextFiveDaysByCity(cityId, dateForWeather, isFarenheit);

            if(result == null)
            {
                return BadRequest("No se encontraron registros con los parametros enviados");
            }

            return Ok(result);
        }

    }
}
