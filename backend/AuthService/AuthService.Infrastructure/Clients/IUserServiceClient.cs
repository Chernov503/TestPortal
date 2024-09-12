using AuthServce.Application;
using Contracts.Requests;
using Contracts.Responses;

namespace AuthService.Infrastructure.Clients
{
    public interface IUserServiceClient
    {
        Task<Result<UserServiceRegistrationResponse>> RegisterUserAsync(UserServiceRegistrationRequest request);
    }
}