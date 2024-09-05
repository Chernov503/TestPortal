using FluentValidation;

namespace AuthService.Api.DTO.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator() 
        {
            RuleFor(register => register.password)
                .NotNull().WithMessage("Password shoudn't be null")
                .NotEmpty().WithMessage("Password shoudn't be empty")
                .MinimumLength(8).WithMessage("Password can't be less than 8")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");

            RuleFor(register => register.email)
                .EmailAddress().WithMessage("Not correct email");

            RuleFor(register => register.firstName)
                .NotNull().WithMessage("Name shoudn't be null")
                .NotEmpty().WithMessage("Name shoudn't be empty")
                .MaximumLength(100).WithMessage("Too long name (more than 100)")
                .Matches(@"^[a-zA-Z ]+$").WithMessage("Incorrect symbols");

            RuleFor(register => register.surName)
                .NotNull().WithMessage("Surname shoudn't be null")
                .NotEmpty().WithMessage("Surname shoudn't be empty")
                .MaximumLength(100).WithMessage("Too long Surname (more than 100)")
                .Matches(@"^[a-zA-Z ]+$").WithMessage("Incorrect symbols");

            RuleFor(register => register.company)
                .NotNull().WithMessage("Company shoudn't be null")
                .NotEmpty().WithMessage("Company shoudn't be empty")
                .MaximumLength(500).WithMessage("Too long Company name (more than 500)");
        }
    }
}
