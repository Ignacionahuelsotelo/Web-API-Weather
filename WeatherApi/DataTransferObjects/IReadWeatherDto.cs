namespace WeatherApi.DataTransferObjects
{
    public interface IReadWeatherDto
    {
        string DayOfWeekName { get; }
        string CityName { get;  }
        string CountryName { get; }
        int MaxTemperature { get; }
        int MinTemperature { get; }
        DateTime Date { get; }
        bool IsFarenheit { get; }
        
    }
}
