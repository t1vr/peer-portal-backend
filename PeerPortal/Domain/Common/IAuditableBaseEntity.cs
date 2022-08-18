
namespace Domain.Common
{
    public interface IAuditableBaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }
}
