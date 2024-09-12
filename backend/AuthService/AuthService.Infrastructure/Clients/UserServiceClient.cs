using FluentValidation;
using System.Net.Http.Json;
using AuthServce.Application;
using AuthServce.Application.Clients.UserService.Interface;
using AuthService.Contracts.Responses;
using AuthService.Contracts.Requests;

namespace AuthService.Infrastructure.Clients
{
    public class UserServiceClient(HttpClient httpClient,
                                   IValidator<UserServiceRegistrationResponse> validator) : IUserServiceClient
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly IValidator<UserServiceRegistrationResponse> _validator = validator;

        public async Task<Result<UserServiceRegistrationResponse>> RegisterUserAsync(UserServiceRegistrationRequest request, CancellationToken ct)
        {
            var content = JsonContent.Create(request);
            var response = await _httpClient.PostAsync("register", content, ct); //TODO: прикрутить реальный url

            if (!response.IsSuccessStatusCode)
            {
                return Result<UserServiceRegistrationResponse>.FromError($"UserService registration error. Code: {response.StatusCode}");
            }

            var responseContent = await response.Content.ReadFromJsonAsync<UserServiceRegistrationResponse>();

            var validationResult = _validator.Validate(responseContent!);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                return Result<UserServiceRegistrationResponse>.FromError($"Validation failed: {errors}");
            }

            return Result<UserServiceRegistrationResponse>.FromSuccess(responseContent!);
        }
    }
}
