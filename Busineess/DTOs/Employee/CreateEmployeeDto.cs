using Entities.Enums;

namespace Busineess.DTOs.Employee
{
    public class CreateEmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long IdentityNumber { get; set; }
        public int BirthYear { get; set; }
        public string Email { get; set; }
        public EmployeeRole Role { get; set; }
    }
}
