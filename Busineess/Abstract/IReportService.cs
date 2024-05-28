using Busineess.DTOs.Issue;
using Busineess.DTOs.Project;
using Business.Wrappers;
using Entities;

namespace Busineess.Abstract
{
    public interface IReportService
    {
        Task<IDataResult<List<GetProjectEmployeeCountDto>>> GetProjectsEmployeeCount(int companyId);
        Task<List<GetIssueReportDto>> GetIssueReport(int companyId);
    }
}


