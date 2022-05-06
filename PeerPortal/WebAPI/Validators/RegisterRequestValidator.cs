using Application.Request;
using FluentValidation;

namespace WebAPI.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(registerRequest => registerRequest.FirstName).NotEmpty();
            RuleFor(registerRequest => registerRequest.LastName).NotEmpty();
            RuleFor(registerRequest => registerRequest.UserName).NotEmpty();
            RuleFor(registerRequest => registerRequest.Email).EmailAddress().NotEmpty();
            RuleFor(registerRequest => registerRequest.Password).NotEmpty().Equal(registerRequest => registerRequest.ConfirmPassword);

        }
    }
}
