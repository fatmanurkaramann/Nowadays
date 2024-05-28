using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Company : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();
    }
}
