using Application.Request_Model;
using FluentValidation;

namespace WebAPI.Validators
{
    public class TeamRequestValidator:AbstractValidator<TeamRequest>
    {
        public TeamRequestValidator()
        {
            RuleFor(teamRequest => teamRequest.Name).NotEmpty();
        }
    }
}
