using api_auth.Models;

namespace api_auth.Repositories
{
    public static class UserRepository
    {
        private static List<User> _users = new List<User>()
        {
            new User
            {
                UserId = 1,
                UserIdentification = "JohnDoe@email.com",
                UserPassword = "JohnDoe123",
                UserRolesList = new List<UserRoles>
                {
                    new UserRoles { UserRoleId = 1, UserRoleDescription = "Search Service" },
                    new UserRoles { UserRoleId = 2, UserRoleDescription = "Update Service" }
                }
            },
            new User
            {
                UserId = 2,
                UserIdentification = "PierreBorne@email.com",
                UserPassword = "bOrNePiErEe",
                UserRolesList = new List<UserRoles>
                {
                    new UserRoles { UserRoleId = 1, UserRoleDescription = "Search Service" },
                    new UserRoles { UserRoleId = 2, UserRoleDescription = "Update Service" },
                    new UserRoles { UserRoleId = 3, UserRoleDescription = "Delete Service" },
                    new UserRoles { UserRoleId = 4, UserRoleDescription = "Create Service" }
                }
            }
        };
        public static User? GetUser(int userId)
        {
            return _users.FirstOrDefault(user => user.UserId == userId);
        }

        public static User? GetUserByIdentification(string userIdentification)
        {
            return _users.FirstOrDefault(user => user.UserIdentification == userIdentification);
        }
    }
}
