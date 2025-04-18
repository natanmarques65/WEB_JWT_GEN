namespace api_auth.Models
{
    public class Auth
    {
        public User User { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
