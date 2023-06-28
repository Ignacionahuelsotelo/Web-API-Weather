namespace WeatherApi.Models
{
    public class Weather
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int MaxTemperature { get; set; }
        public int MinTemperature { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }

    }
}
