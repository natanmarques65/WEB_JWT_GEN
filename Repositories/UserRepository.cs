using api_auth.Models;

namespace api_auth.Repositories
{
    public static class UserRepository
    {
        public static User GetUser(int userId)
        {
            var users = new List<User>();
            users.Add(
                new User
                {
                    UserId = 1,
                    UserIdentification = "John Doe",
                    UserPassword = "JohnDoe123",
                    UserRolesList = new List<UserRoles>
                {
                    new UserRoles { UserRoleId = 1, UserRoleDescription = "Search Service" },
                    new UserRoles { UserRoleId = 2, UserRoleDescription = "Update Service" }
                } });
            users.Add(
                new User
                {
                    UserId = 2,
                    UserIdentification = "Pierre Borne",
                    UserPassword = "bOrNePiErEe",
                    UserRolesList = new List<UserRoles>
                {
                    new UserRoles { UserRoleId = 1, UserRoleDescription = "Search Service" },
                    new UserRoles { UserRoleId = 2, UserRoleDescription = "Update Service" },
                    new UserRoles { UserRoleId = 3, UserRoleDescription = "Delete Service" },
                    new UserRoles { UserRoleId = 4, UserRoleDescription = "Create Service" }
                }}
                );

            return users.FirstOrDefault(user => user.UserId == userId);
        }
    }
}
