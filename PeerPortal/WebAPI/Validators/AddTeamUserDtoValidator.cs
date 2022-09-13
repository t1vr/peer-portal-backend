using Application.Shared.Dtos;
using FluentValidation;

namespace WebAPI.Validators
{
    public class AddTeamUserDtoValidator : AbstractValidator<AddTeamUserDto>
    {
        public AddTeamUserDtoValidator()
        {
            RuleFor(x => x.ApplicationUserId).NotEmpty().NotNull();
            RuleFor(x => x.TeamId).NotEmpty().NotNull();
        }
    }
}
