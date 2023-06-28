namespace WeatherApi.DataTransferObjects.Factories.Dto
{
    public class ReadWeatherDto : IReadWeatherDto
    {
        public string CityName { get; set; }

        public string CountryName { get; set; }

        public int MaxTemperature { get; set; }

        public int MinTemperature { get; set; }

        public DateTime Date { get; set; }

        public string DayOfWeekName { get; set; }

        public bool IsFarenheit { get; set; }
    }
}
