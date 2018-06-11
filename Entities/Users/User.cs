namespace Entities.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
