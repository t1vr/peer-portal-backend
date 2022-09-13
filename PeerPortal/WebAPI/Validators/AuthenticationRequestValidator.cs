using Application.Request_Model;
using FluentValidation;

namespace WebAPI.Validators
{
    public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
    {
        public AuthenticationRequestValidator()
        {
            RuleFor(authenticationRequest => authenticationRequest.Email).EmailAddress().NotEmpty();
            RuleFor(authenticationRequest => authenticationRequest.Password).NotEmpty();
        }
    }
}
