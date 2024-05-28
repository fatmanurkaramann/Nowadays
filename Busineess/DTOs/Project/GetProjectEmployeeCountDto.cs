namespace Busineess.DTOs.Project
{
    public class GetProjectEmployeeCountDto
    {
        public int ProjectId { get; set; }
        public string ProjectKey { get; set; }
        public string ProjectName { get; set; }
        public int EmployeeCount { get; set; }
        public int TesterCount { get; set; }
        public int DeveloperCount { get; set; }
        public int ManagerCount { get; set; }
    }
}
