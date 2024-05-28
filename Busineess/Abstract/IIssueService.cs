using Busineess.DTOs.Employee;
using Busineess.DTOs.Issue;
using Business.Wrappers;
using Entities;

namespace Busineess.Abstract
{
    public interface IIssueService
    {
        Task<IDataResult<Issue>> AddAsync(CreateIssueDto issueDto);
        Task<IDataResult<Issue>> DeleteAsync(int id);
        Task<IDataResult<Issue>> UpdateAsync(UpdateIssueDto issueDto);
        Task<IDataResult<Issue>> AssignEmployeeToIssue(AssignEmployeeToIssueDto assignEmployeeToIssueDto);
    }
}
