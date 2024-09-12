using FluentValidation;

namespace AuthService.Infrastructure.Clients.DTO.Validators
{
    public class UserServiceRegistrationResponseValidator : AbstractValidator<UserServiceRegistrationResponse>
    {
        #region Const

        private const int MAX_LENGHT_COMPANY_NAME = 500;

        #endregion
        public UserServiceRegistrationResponseValidator()
        {
            RuleFor(register => register.Id)
                .NotEmpty().WithMessage("Id shouldn't be empty")
                .NotNull().WithMessage("Id shouldn't be null")
                .NotEqual(Guid.Empty).WithMessage("Id shouldn't be an empty GUID");

            RuleFor(register => register.Company)
                .NotNull().WithMessage("Company name should not be null")
                .NotEmpty().WithMessage("Company name should not be empty")
                .MaximumLength(MAX_LENGHT_COMPANY_NAME).WithMessage($"Company name should not exceed {MAX_LENGHT_COMPANY_NAME} characters")
                .Matches(@"^[a-zA-Z0-9\s]*$").WithMessage("Company name contains invalid characters");

            RuleFor(register => register.Role)
                .NotNull().WithMessage("Invalid response");

        }
    }
}
