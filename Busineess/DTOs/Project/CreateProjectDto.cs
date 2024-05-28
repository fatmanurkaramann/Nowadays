using Entities.Enums;

namespace Busineess.DTOs.Project
{
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ProjectStatus Status { get; set; }
        public int CompanyId { get; set; }
    }
}
