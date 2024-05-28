namespace Core.Entities
{
    public class BaseEntity : AuditLogEntity
    {
        public int Id { get; set; }
    }

    public abstract class AuditLogEntity
    {
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }
    }
}
