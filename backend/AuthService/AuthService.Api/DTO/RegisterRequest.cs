namespace AuthService.Api.DTO
{
    public record RegisterRequest(
        string password,
        string firstName,
        string surName,
        string email,
        string company);
}
