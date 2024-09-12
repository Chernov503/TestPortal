using AuthService.Contracts.Requests;
using AuthService.Contracts.Responses;

namespace AuthServce.Application.Clients.UserService.Interface
{
    public interface IUserServiceClient
    {
        Task<Result<UserServiceRegistrationResponse>> RegisterUserAsync(UserServiceRegistrationRequest request, CancellationToken ct);
    }
}