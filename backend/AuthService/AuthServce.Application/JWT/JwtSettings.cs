namespace AuthServce.Application.JWT
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = string.Empty;
        public double ExpiresHours { get; set; }
    }
}
