using api_auth.Models;

namespace api_auth.Repositories
{
    public static class RolesRepository
    {
       
        public static List<UserRoles> GetUserRolesById(int userId)
        {
            var roles = new List<UserRoles>();
            var user = UserRepository.GetUser(userId);

            if(user == null)
            {
                return roles;
            }

            roles = user.UserRolesList;

            return roles;
        }
    }
}
