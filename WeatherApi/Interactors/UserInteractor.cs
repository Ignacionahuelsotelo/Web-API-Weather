using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WeatherApi.Controllers.Dtos;
using WeatherApi.Models;
using WeatherApi.Services;

namespace WeatherApi.Interactors
{
    public class UserInteractor
    {

        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserInteractor(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        public async Task<string> Login(PostUserLoginDto userLogin)
        {
            var user = await _userService.GetUser(userLogin.Email,userLogin.Password);

            if (user == null)
            {
                return null;
            }

            string jwtToken = GenerateToken(user);

            return jwtToken;
        }

        private string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }
    }
}
