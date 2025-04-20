namespace api_auth.Environment
{
    public static class JwtSettings
    {
        public static string JwtSecret { get; private set; } = "";

        public static void LoadJwtSettings(IConfiguration configuration)
        {
            JwtSecret = configuration.GetValue<string>("JwtSettings:JwtSecret" ?? throw new Exception("Jwt Secret not found"));
        }
    }
}
