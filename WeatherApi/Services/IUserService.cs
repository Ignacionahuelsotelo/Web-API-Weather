using WeatherApi.DataTransferObjects;
using WeatherApi.Models;

namespace WeatherApi.Services
{
    public interface IUserService
    {
        Task<User?> GetUser(string email,string password);
    }
}
