namespace api_auth.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserIdentification { get; set; }
        public string UserPassword { get; set; }
        public List<UserRoles> UserRolesList { get; set; }
    }
}
