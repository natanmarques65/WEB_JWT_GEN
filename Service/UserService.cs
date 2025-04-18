using api_auth.Models;
using api_auth.Repositories;

namespace api_auth.Service
{
    public class UserService
    {
        public async Task<User> GetUser(User user)
        {
            return UserRepository.GetUser(user.UserId);
        }
    }
}
