using Entities.Enums;

namespace Busineess.DTOs.Issue
{
    public class GetIssueReportDto
    {
        public int ProjectId { get; set; }
        public string ProjectKey { get; set; }
        public string ProjectName { get; set; }
        public int IssueCount { get; set; }
        public int UnresolvedIssueCount { get; set; }
        public int ResolvedIssueCount { get; set; }
        public int HightPriorityIssueCount { get; set; }
        public int MediumPriorityIssueCount { get; set; }
        public int LowPriorityIssueCount { get; set; }
    }
}
