namespace WeatherApi.Models
{
    public class User
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is User user &&
                   Id == user.Id &&
                   Name == user.Name &&
                   Email == user.Email &&
                   Password == user.Password;
        }
    }


}
