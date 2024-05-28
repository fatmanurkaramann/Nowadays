using AutoMapper;
using Busineess.Abstract;
using Busineess.DTOs.Employee;
using Busineess.DTOs.Issue;
using Busineess.Rules;
using Business.Wrappers;
using Core.Exceptions;
using Core.Wrappers;
using DataAccess.UoW;
using Entities;
using Entities.Constants;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace Busineess.Concrete
{
    public class IssueService(IUnitOfWork unitOfWork, IMapper mapper, IssueBusinessRules issueBusinessRules) : IIssueService
    {
        public async Task<IDataResult<Issue>> AddAsync(CreateIssueDto issueDto)
        {
            await issueBusinessRules.CheckIfProjectIsExist(issueDto.ProjectId);
            Issue issue = mapper.Map<Issue>(issueDto);
            OperationResult<Issue>  result = await unitOfWork.Issues.AddAsync(issue);
            if(result.IsSuccess)
                await unitOfWork.CommitAsync();

            return DataResult<Issue>.CreateResult(result, EntityType.Issue, ActionType.Add);
        }

        public async Task<IDataResult<Issue>> AssignEmployeeToIssue(AssignEmployeeToIssueDto assignEmployeeToIssueDto)
        {
            Issue issue = await unitOfWork.Issues.GetAsync(
                predicate: i => i.Id == assignEmployeeToIssueDto.IssueId,
                    include: query => query.Include(i => i.Employees))
                        ?? throw new NotFoundException(Messages.CreateNotFoundMessage(EntityType.Issue, assignEmployeeToIssueDto.IssueId));

            Employee employee = await unitOfWork.Employees.GetByIdAsync(assignEmployeeToIssueDto.EmployeeId)
                ?? throw new NotFoundException(Messages.CreateNotFoundMessage(EntityType.Employee, assignEmployeeToIssueDto.EmployeeId));

            issueBusinessRules.CheckIfEmployeeAlreadyAssign(employee.Id, issue.Employees);

            issue.Employees.Add(employee);

            OperationResult<Issue> result = await unitOfWork.Issues.UpdateAsync(issue);

            if(result.IsSuccess)
                await unitOfWork.CommitAsync();

            return DataResult<Issue>.CreateResult(result, EntityType.Issue, ActionType.Assign);
        }

        public async Task<IDataResult<Issue>> DeleteAsync(int id)
        {
            OperationResult<Issue> result = await unitOfWork.Issues.DeleteByIdAsync(id);
            if(result.IsSuccess)
                await unitOfWork.CommitAsync();

            return DataResult<Issue>.CreateResult(result, EntityType.Issue, ActionType.Delete);
        }

        public async Task<IDataResult<Issue>> UpdateAsync(UpdateIssueDto issueDto)
        {
            Issue issue = mapper.Map<Issue>(issueDto);
            OperationResult<Issue> result = await unitOfWork.Issues.UpdateAsync(issue);
            if(result.IsSuccess)
                await unitOfWork.CommitAsync();

            return DataResult<Issue>.CreateResult(result, EntityType.Issue, ActionType.Update);
        }
    }
}
