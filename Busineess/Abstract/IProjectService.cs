using Busineess.DTOs.Employee;
using Busineess.DTOs.Project;
using Business.Wrappers;
using Entities;

namespace Busineess.Abstract
{
    public interface IProjectService
    {
        Task<IDataResult<Project>> AddAsync(CreateProjectDto projectDto);
        Task<IDataResult<Project>> DeleteAsync(int id);
        Task<IDataResult<Project>> UpdateAsync(UpdateProjectDto projectDto);
        Task<IDataResult<Project>> AssignEmployeeToProject(AssignEmployeeToProjectDto assignEmployeeToProjectDto);
    }
}
