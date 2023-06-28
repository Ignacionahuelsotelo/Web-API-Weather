using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Models;
using WeatherApi.Services;

namespace WeatherApi.NUnitTests
{
    [TestFixture]
    public class WeatherNUnitTests
    {
        Mock<IWeatherService> mockWeatherService = new Mock<IWeatherService>();
        DateTime dateTest = new DateTime(2023, 1, 1);

        [SetUp]
        public void Setup()
        {
            

            mockWeatherService
                .Setup(s => s.GetWeatherByCountryAndCity(1, 1))
                .ReturnsAsync(new List<Weather>() { 
                    new Weather() { CityId = 1, CountryId = 1, CityName = "Buenos Aires", CountryName = "Argentina", MaxTemperature = 30, MinTemperature = 20, Id = 10 },
                    new Weather() { CityId = 1, CountryId = 1, CityName = "Buenos Aires", CountryName = "Argentina", MaxTemperature = 30, MinTemperature = 20, Id = 11 },
                    new Weather() { CityId = 1, CountryId = 1, CityName = "Buenos Aires", CountryName = "Argentina", MaxTemperature = 30, MinTemperature = 20, Id = 12 } , 
                    new Weather() { CityId = 1, CountryId = 1, CityName = "Buenos Aires", CountryName = "Argentina", MaxTemperature = 30, MinTemperature = 20, Id = 13 } , 
                    new Weather() { CityId = 1, CountryId = 1, CityName = "Buenos Aires", CountryName = "Argentina", MaxTemperature = 30, MinTemperature = 20, Id = 14 },
                    new Weather() { CityId = 1, CountryId = 1, CityName = "Buenos Aires", CountryName = "Argentina", MaxTemperature = 30, MinTemperature = 20, Id = 15 }});

            mockWeatherService
                .Setup(s => s.GetWeatherForNextFiveDaysByCity(1, dateTest))
                .ReturnsAsync(new List<Weather>() {
                    new Weather() { CityId = 1, CountryId = 1, CityName = "Buenos Aires", CountryName = "Argentina", MaxTemperature = 30, MinTemperature = 20, Id = 10,Date = dateTest },
                    new Weather() { CityId = 1, CountryId = 1, CityName = "Buenos Aires", CountryName = "Argentina", MaxTemperature = 30, MinTemperature = 20, Id = 11 ,Date = dateTest.AddDays(1)},
                    new Weather() { CityId = 1, CountryId = 1, CityName = "Buenos Aires", CountryName = "Argentina", MaxTemperature = 30, MinTemperature = 20, Id = 12,Date = dateTest.AddDays(1) } ,
                    new Weather() { CityId = 1, CountryId = 1, CityName = "Buenos Aires", CountryName = "Argentina", MaxTemperature = 30, MinTemperature = 20, Id = 13 ,Date = dateTest.AddDays(1)} ,
                    new Weather() { CityId = 1, CountryId = 1, CityName = "Buenos Aires", CountryName = "Argentina", MaxTemperature = 30, MinTemperature = 20, Id = 14,Date = dateTest.AddDays(1) }});



        }

        [Test]
        public async Task GetWeatherByCorrectCityAndCorrectCountry()
        {
            var weatherList = mockWeatherService.Object.GetWeatherByCountryAndCity(1,1);

            Assert.IsNotNull(weatherList);
                
                
        }

        [Test]
        public async Task GetNullWeatherByIncorrectCityAndCorrectCountry()
        {
            var weatherList = mockWeatherService.Object.GetWeatherByCountryAndCity(2, 1);

            Assert.IsNull(weatherList.Result.FirstOrDefault());


        }

        [Test]
        public async Task GetNullWeatherByCorrectCityAndIncorrectCountry()
        {
            var weatherList = mockWeatherService.Object.GetWeatherByCountryAndCity(1, 2);

            Assert.IsNull(weatherList.Result.FirstOrDefault());

        }

        [Test]
        public async Task GetWeatherForNextFiveDaysReturnsAListWithExactlyFiveElements()
        {
            DateTime dateTest2 = new DateTime(2023, 1, 1);
            var weatherList = mockWeatherService.Object.GetWeatherForNextFiveDaysByCity(1,dateTest2);

            Assert.AreEqual(5, weatherList.Result.Count());
        }

        [Test]
        public async Task GetWeatherForNextFiveDaysWithCorrectDateAndIncorrectCityReturnsNull()
        {
            DateTime dateTest2 = new DateTime(2023, 1, 1);
            var weatherList = mockWeatherService.Object.GetWeatherForNextFiveDaysByCity(2, dateTest2);

            Assert.IsNull(weatherList.Result.FirstOrDefault());
        }
    } 
}
