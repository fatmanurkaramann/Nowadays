using Core.Entities;
using Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Employee : BaseEntity
    {
        [Required, MaxLength(50), MinLength(3)]
        public string FirstName { get; set; }
        [Required, MaxLength(50), MinLength(3)]
        public string LastName { get; set; }
        public long IdentityNumber { get; set; }
        public int BirthYear { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public EmployeeRole Role { get; set; }

        public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>(); 
        public virtual ICollection<Issue> Issues { get; set; } = new HashSet<Issue>();
    }
}
