namespace Application.Shared.Dtos
{
    /// <summary>
    /// Dto for adding TeamUser
    /// </summary>
    public class AddTeamUserDto
    {
        public string ApplicationUserId { get; set; }
        public string TeamId { get; set; }
        public IList<short>? Permissions { get; set; }
    }
}
