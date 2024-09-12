using AuthServce.Application;
using FluentValidation;
using System.Net.Http.Json;
using Contracts.Requests;
using Contracts.Responses;

namespace AuthService.Infrastructure.Clients
{
    public class UserServiceClient(HttpClient httpClient,
                                   IValidator<UserServiceRegistrationResponse> validator) : IUserServiceClient
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly IValidator<UserServiceRegistrationResponse> _validator = validator;

        public async Task<Result<UserServiceRegistrationResponse>> RegisterUserAsync(UserServiceRegistrationRequest request)
        {
            var content = JsonContent.Create(request);
            var response = await _httpClient.PostAsync("register", content);

            if (!response.IsSuccessStatusCode)
            {
                return Result<UserServiceRegistrationResponse>.FromError($"UserService registration error. Code: {response.StatusCode}");
            }

            var responseContent = await response.Content.ReadFromJsonAsync<UserServiceRegistrationResponse>();

            var validationResult = _validator.Validate(responseContent);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                return Result<UserServiceRegistrationResponse>.FromError($"Validation failed: {errors}");
            }

            return Result<UserServiceRegistrationResponse>.FromSuccess(responseContent!);
        }
    }
}
