using Business.Wrappers;
using Core.Exceptions;
using DataAccess.UoW;
using Entities;
using Entities.Constants;
using Entities.Enums;

namespace Busineess.Rules
{
    public class ProjectBusinessRules(IUnitOfWork unitOfWork)
    {
        public async Task CheckIfKeyIsUnique(string key)
        {
            Project? project = await unitOfWork.Projects.GetAsync(p => p.Key.Equals(key));
            if(project is not null)
                throw new BusinessException($"{key} key'i ile zaten bir proje kayıtlıdır.");
        }

        public async Task CheckIfCompanyIsExist(int companyId)
        {
            _ = await unitOfWork.Companies.GetByIdAsync(companyId)
                ?? throw new NotFoundException(Messages.CreateNotFoundMessage(EntityType.Company, companyId));
        }

        public void CheckIfEmployeeAlreadyAssign(int employeeId, ICollection<Employee> employees)
        {
            if(employees.Any(e=> e.Id == employeeId))
                throw new BusinessException(Messages.CreateMessage(EntityType.Employee, ActionType.Assign, false));
        }
    }
}
