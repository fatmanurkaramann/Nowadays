using AutoMapper;
using Busineess.Abstract;
using Busineess.DTOs.Employee;
using Busineess.DTOs.Project;
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
    public class ProjectService(IUnitOfWork unitOfWork, ProjectBusinessRules projectBusinessRules, IMapper mapper) : IProjectService
    {

        public async Task<IDataResult<Project>> AddAsync(CreateProjectDto projectDto)
        {
            await projectBusinessRules.CheckIfCompanyIsExist(projectDto.CompanyId);
            await projectBusinessRules.CheckIfKeyIsUnique(projectDto.Key);

            Project project = mapper.Map<Project>(projectDto);
            OperationResult<Project> result = await unitOfWork.Projects.AddAsync(project);

            if (result.IsSuccess)
                await unitOfWork.CommitAsync();

            return DataResult<Project>.CreateResult(result, EntityType.Project, ActionType.Add);

        }

        public async Task<IDataResult<Project>> AssignEmployeeToProject(AssignEmployeeToProjectDto assignEmployeeToProjectDto)
        {
            Project project = await unitOfWork.Projects.GetAsync(predicate: p=> p.Id == assignEmployeeToProjectDto.ProjectId,
                include: query=> query.Include(p=>p.Employees))
                ?? throw new NotFoundException(Messages.CreateNotFoundMessage(EntityType.Project, assignEmployeeToProjectDto.ProjectId));


            Employee employee = await unitOfWork.Employees.GetByIdAsync(assignEmployeeToProjectDto.EmployeeId)
                ?? throw new NotFoundException(Messages.CreateNotFoundMessage(EntityType.Employee, assignEmployeeToProjectDto.EmployeeId));

            projectBusinessRules.CheckIfEmployeeAlreadyAssign(employee.Id, project.Employees);
            project.Employees.Add(employee);

            OperationResult<Project> result = await unitOfWork.Projects.UpdateAsync(project);
            if (result.IsSuccess)
                await unitOfWork.CommitAsync();

            return DataResult<Project>.CreateResult(result, EntityType.Project, ActionType.Assign);
        }

        public async Task<IDataResult<Project>> DeleteAsync(int id)
        {
            OperationResult<Project> result = await unitOfWork.Projects.DeleteByIdAsync(id);
            if (result.IsSuccess)
                await unitOfWork.CommitAsync();

            return DataResult<Project>.CreateResult(result, EntityType.Project, ActionType.Delete);
        }
        public async Task<IDataResult<Project>> UpdateAsync(UpdateProjectDto projectDto)
        {
            await projectBusinessRules.CheckIfCompanyIsExist(projectDto.CompanyId);
            await projectBusinessRules.CheckIfKeyIsUnique(projectDto.Key);

            Project project = mapper.Map<Project>(projectDto);
            OperationResult<Project> result = await unitOfWork.Projects.UpdateAsync(project);
            if (result.IsSuccess)
                await unitOfWork.CommitAsync();

            return DataResult<Project>.CreateResult(result, EntityType.Project, ActionType.Update);
        }
    }
}
