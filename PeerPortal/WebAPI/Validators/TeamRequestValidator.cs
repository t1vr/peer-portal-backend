using Application.Request_Model;
using FluentValidation;

namespace WebAPI.Validators
{
    public class TeamRequestValidator:AbstractValidator<CreateTeamRequest>
    {
        public TeamRequestValidator()
        {
            RuleFor(teamRequest => teamRequest.Name).NotEmpty();
        }
    }
}
