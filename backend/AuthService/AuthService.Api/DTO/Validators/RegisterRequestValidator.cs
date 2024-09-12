using FluentValidation;

namespace AuthService.Api.DTO.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        #region Const

        private const int MAX_LENGHT_COMPANY_NAME = 500;
        private const int MAX_LENGHT_FIRST_NAME = 100;
        private const int MAX_LENGHT_SECOND_NAME = 100;
        private const int MIN_LENGHT_PASS = 8;

        #endregion
        public RegisterRequestValidator() 
        {
            RuleFor(register => register.password)
                .NotNull().WithMessage("Password shoudn't be null")
                .NotEmpty().WithMessage("Password shoudn't be empty")
                .MinimumLength(MIN_LENGHT_PASS).WithMessage($"Password can't be less than {MIN_LENGHT_PASS}")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");

            RuleFor(register => register.email)
                .EmailAddress().WithMessage("Not correct email");

            RuleFor(register => register.firstName)
                .NotNull().WithMessage("Name shoudn't be null")
                .NotEmpty().WithMessage("Name shoudn't be empty")
                .MaximumLength(MAX_LENGHT_FIRST_NAME).WithMessage($"Too long name (more than {MAX_LENGHT_FIRST_NAME})")
                .Matches(@"^[a-zA-Z ]+$").WithMessage("Incorrect symbols");

            RuleFor(register => register.surName)
                .NotNull().WithMessage("Surname shoudn't be null")
                .NotEmpty().WithMessage("Surname shoudn't be empty")
                .MaximumLength(MAX_LENGHT_SECOND_NAME).WithMessage($"Too long Surname (more than {MAX_LENGHT_SECOND_NAME})")
                .Matches(@"^[a-zA-Z ]+$").WithMessage("Incorrect symbols");

            RuleFor(register => register.company)
                .NotNull().WithMessage("Company shoudn't be null")
                .NotEmpty().WithMessage("Company shoudn't be empty")
                .MaximumLength(MAX_LENGHT_COMPANY_NAME).WithMessage($"Too long Company name (more than {MAX_LENGHT_COMPANY_NAME})");
        }
    }
}
