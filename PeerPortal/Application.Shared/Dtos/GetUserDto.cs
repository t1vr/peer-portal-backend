namespace Application.Shared.Dtos
{
    /// <summary>
    /// Dto for fetching ApplicationUser
    /// </summary>
    public class GetUserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
