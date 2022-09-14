using Domain.Common;

namespace Application.Shared.Dtos
{
    /// <summary>
    /// Dto model for Team 
    /// </summary>
    public class GetTeamDto : IAuditableBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public IList<GetUserDto> Users { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }
}