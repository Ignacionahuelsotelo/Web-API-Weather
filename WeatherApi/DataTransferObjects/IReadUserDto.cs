namespace WeatherApi.DataTransferObjects
{
    public interface IReadUserDto
    {
        int Id { get; }
        string Email { get; }
        string Password { get; }

    }

    public interface IUserLoginDto
    {
        string Email { get; }
        string Password { get; }
    }
}
