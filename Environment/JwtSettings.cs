namespace api_auth.Environment
{
    public static class JwtSettings
    {
        public static string JwtSecret { get; private set; } = "";
        public static string JwtRefreshTokenIssuer { get; private set; } = "";
        public static string JwtRefreshTokenAudiance { get; private set; } = "";

        public static void LoadJwtSettings(IConfiguration configuration)
        {
            JwtSecret = configuration.GetValue<string>("JwtSettings:JwtSecret" ?? throw new Exception("Jwt Secret not found"));
            JwtRefreshTokenIssuer = configuration.GetValue<string>("JwtSettings:RefreshToken:Issuer" ?? throw new Exception("Jwt Refresh Token Issuer not found"));
            JwtRefreshTokenAudiance = configuration.GetValue<string>("JwtSettings:RefreshToken:Audience" ?? throw new Exception("Jwt Refresh Token  Audiance not found"));
        }
    }
}
