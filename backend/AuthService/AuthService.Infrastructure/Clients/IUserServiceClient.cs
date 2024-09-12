using AuthServce.Application;
using AuthService.Infrastructure.Clients.DTO;

namespace AuthService.Infrastructure.Clients
{
    public interface IUserServiceClient
    {
        Task<Result<UserServiceRegistrationResponse>> RegisterUserAsync(UserServiceRegistrationRequest request);
    }
}