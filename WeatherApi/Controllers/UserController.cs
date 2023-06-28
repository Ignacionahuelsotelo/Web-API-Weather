using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherApi.Context;
using WeatherApi.DataTransferObjects;
using WeatherApi.Models;
using WeatherApi.Services;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WeatherApi.Controllers.Dtos;
using WeatherApi.Interactors;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserInteractor _userInteractor;
        
        public UserController(UserInteractor userInteractor)
        {
            _userInteractor = userInteractor;
            
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult> Login(PostUserLoginDto userLogin)
        {
            var loginToken = await _userInteractor.Login(userLogin);

            if (loginToken == null)
            {
                return BadRequest(new { message = "Credenciales Invalidas" });
            }

            return Ok( new { token = loginToken});
        }

        
        
    }
}
