using Core.Entities;
using Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Issue : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Range(1, 256, ErrorMessage = "The value must be between 1 and 256.")]
        public short? StoryPoint { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public IssuePriority Priority { get; set; }
        public IssueStatus Status { get; set; }
        [NotMapped]
        public string IssueKey
        {
            get
            {
                return $"{Project?.Key}-{Id}";
            }
        }
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
