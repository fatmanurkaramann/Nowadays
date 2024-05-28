using Core.Entities;
using Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Project : BaseEntity
    {
        [Required, MaxLength(100), MinLength(3)]
        public string Name { get; set; }
        [Required, MaxLength(10), MinLength(3)]
        public string Key { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ProjectStatus Status { get; set; }
        public int? CompanyId { get; set; }
        public virtual Company? Company { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
        public virtual ICollection<Issue> Issues { get; set; } = new HashSet<Issue>();
    }
}
