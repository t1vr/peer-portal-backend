
namespace Application.Request_Model
{
    /// <summary>
    /// Request model for creating team.
    /// </summary>
    public class CreateTeamRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
