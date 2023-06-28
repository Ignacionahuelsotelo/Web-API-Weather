using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WeatherApi.Context;
using WeatherApi.DataTransferObjects;
using WeatherApi.Models;

namespace WeatherApi.Services
{
    public class UserService : IUserService
    {
        private readonly AplicattionDbContext _context;

        public UserService(AplicattionDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUser(string email, string password)
        {
            return await _context.User.SingleOrDefaultAsync(f => f.Email == email && f.Password == password);
        }

        
    }
}
