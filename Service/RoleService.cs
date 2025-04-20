using api_auth.Models;
using api_auth.Repositories;

namespace api_auth.Service
{
    public class RoleService
    {
        public List<UserRoles> GetUserRoleById(int userId)
        {
            return RolesRepository.GetUserRolesById(userId);
        }
    }
}
