using Application.Shared.Dtos;
using FluentValidation;

namespace WebAPI.Validators
{
    public class CreateTeamDtoValidator : AbstractValidator<CreateTeamDto>
    {
        public CreateTeamDtoValidator()
        {
            RuleFor(teamDto => teamDto.Name).NotEmpty();
        }
    }
}
