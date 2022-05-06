using Application.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(registerRequest=>registerRequest.FirstName).NotEmpty();
            RuleFor(registerRequest => registerRequest.LastName).NotEmpty();
            RuleFor(registerRequest => registerRequest.UserName).NotEmpty();
            RuleFor(registerRequest => registerRequest.Email).EmailAddress().NotEmpty();
            RuleFor(registerRequest => registerRequest.Password).NotEmpty().Equal(registerRequest => registerRequest.ConfirmPassword);

        }
    }
}
