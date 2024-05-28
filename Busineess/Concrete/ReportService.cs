using Busineess.Abstract;
using Busineess.DTOs.Issue;
using Busineess.DTOs.Project;
using Business.Wrappers;
using DataAccess.UoW;
using Entities;
using Entities.Constants;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace Busineess.Concrete
{
    public class ReportService(IUnitOfWork unitOfWork) : IReportService
    {
        public async Task<IDataResult<List<GetProjectEmployeeCountDto>>> GetProjectsEmployeeCount(int companyId)
        {
            IList<Project> projects = await unitOfWork.Projects.GetAllAsync(
                predicate: p => p.CompanyId == companyId,
                include: query=> query.Include(p=> p.Employees));

            List< GetProjectEmployeeCountDto> result = projects.Select(p => new GetProjectEmployeeCountDto
            {
                ProjectId = p.Id,
                ProjectKey = p.Key,
                ProjectName = p.Name,
                EmployeeCount = p.Employees.Count,
                DeveloperCount = p.Employees.Count(e => e.Role == EmployeeRole.Developer),
                TesterCount = p.Employees.Count(e => e.Role == EmployeeRole.Tester),
                ManagerCount = p.Employees.Count(e => e.Role == EmployeeRole.Manager),
            }).ToList();

            return new SuccessDataResult<List<GetProjectEmployeeCountDto>>(result,Messages.GetProjectEmployeeCountReport); 
        }

        public async Task<List<GetIssueReportDto>> GetIssueReport(int companyId)
        {
            IList<Project> projects = await unitOfWork.Projects.GetAllAsync(
                predicate: p => p.CompanyId == companyId,
                include: query => query.Include(p => p.Issues)
            );
            return  projects.Select(p => new GetIssueReportDto
            {
                ProjectId = p.Id,
                ProjectKey = p.Key,
                ProjectName = p.Name,
                IssueCount = p.Issues.Count,
                UnresolvedIssueCount = p.Issues.Count(i => i.Status != IssueStatus.Closed),
                ResolvedIssueCount = p.Issues.Count(i => i.Status == IssueStatus.Closed),
                HightPriorityIssueCount = p.Issues.Count(i => i.Priority == IssuePriority.High),
                MediumPriorityIssueCount = p.Issues.Count(i => i.Priority == IssuePriority.Medium),
                LowPriorityIssueCount = p.Issues.Count(i => i.Priority == IssuePriority.Low)
            }).ToList();
        }

    }
}
