using Core.Exceptions;
using DataAccess.UoW;
using Entities;
using Entities.Constants;
using Entities.Enums;

namespace Busineess.Rules
{
    public class IssueBusinessRules(IUnitOfWork unitOfWork)
    {
        public async Task CheckIfProjectIsExist(int projectId)
        {
            _ = await unitOfWork.Projects.GetByIdAsync(projectId)
                ?? throw new NotFoundException(Messages.CreateNotFoundMessage(EntityType.Project, projectId));
        }

        public void CheckIfEmployeeAlreadyAssign(int employeeId, ICollection<Employee> employees)
        {
            if (employees.Any(e => e.Id == employeeId))
                throw new BusinessException(Messages.CreateMessage(EntityType.Employee, ActionType.Assign, false));
        }
    }
}
