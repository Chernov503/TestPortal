namespace AuthService.Infrastructure.Clients.DTO
{
    public class UserServiceRegistrationRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
    }
}
