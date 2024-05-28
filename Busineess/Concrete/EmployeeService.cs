using AutoMapper;
using Busineess.Abstract;
using Busineess.DTOs.Employee;
using Business.Wrappers;
using Core.Exceptions;
using Core.Helpers;
using Core.Wrappers;
using DataAccess.UoW;
using Entities;
using Entities.Constants;
using Entities.Enums;

namespace Busineess.Concrete
{
    public class EmployeeService(IMapper mapper, IPersonValidationService personValidationService, IUnitOfWork unitOfWork) : IEmployeeService
    {
        public async Task<IDataResult<Employee>> AddAsync(CreateEmployeeDto employeeDto)
        {
            Employee employee = mapper.Map<Employee>(employeeDto);
            await CheckIfLegalPerson(employee);
            employee.Password = PasswordGenerator.Generate(length:15);
            var result = await unitOfWork.Employees.AddAsync(employee);
            if (result.IsSuccess)
                await unitOfWork.CommitAsync();

            return DataResult<Employee>.CreateResult(result, EntityType.Employee, ActionType.Add);

        }

        public async Task<IDataResult<Employee>> DeleteAsync(int id)
        {
            OperationResult<Employee> result = await unitOfWork.Employees.DeleteByIdAsync(id);
            if (result.IsSuccess)
                await unitOfWork.CommitAsync();

            return DataResult<Employee>.CreateResult(result, EntityType.Employee, ActionType.Delete);
        }

        public async Task<IDataResult<Employee>> UpdateAsync(UpdateEmployeeDto employeeDto)
        {
            var employee = mapper.Map<Employee>(employeeDto);
            await CheckIfLegalPerson(employee);
            OperationResult<Employee> result = await unitOfWork.Employees.UpdateAsync(employee);
            if (result.IsSuccess)
                await unitOfWork.CommitAsync();

            return DataResult<Employee>.CreateResult(result, EntityType.Employee, ActionType.Update);
        }

        private async Task CheckIfLegalPerson(Employee employee)
        {
            bool isLegalPerson = await personValidationService.ValidateIdentityNumber(employee.IdentityNumber,
                employee.FirstName, employee.LastName, employee.BirthYear);

            if (!isLegalPerson)
                throw new BusinessException(Messages.InvalidIdentityNumber);
        }
    }
}
