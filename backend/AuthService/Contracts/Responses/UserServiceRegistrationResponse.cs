namespace Contracts.Responses
{
    public class UserServiceRegistrationResponse
    {
        public Guid Id { get; set; }
        public string Company { get; set; } = string.Empty;
        public int Role { get; set; } = 0;
    }
}
