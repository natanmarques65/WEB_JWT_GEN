using api_auth.Models;
using api_auth.Repositories;

namespace api_auth.Service
{
    public class UserService
    {
        public User GetUser(User user)
        {
            return UserRepository.GetUser(user.UserId);
        }

        public User GetUserByIdentification(string userIdentification)
        {
            return UserRepository.GetUserByIdentification(userIdentification);
        }
    }
}
