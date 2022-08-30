
namespace Application.Shared.Dtos
{
    /// <summary>
    /// Request model for creating team.
    /// </summary>
    public class CreateTeamDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
