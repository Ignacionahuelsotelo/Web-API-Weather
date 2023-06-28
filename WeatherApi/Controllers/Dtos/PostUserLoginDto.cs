using WeatherApi.DataTransferObjects;

namespace WeatherApi.Controllers.Dtos
{
    public class PostUserLoginDto : IUserLoginDto
    {
        public string Email {get; set;}

        public string Password { get; set; }
    }


}
