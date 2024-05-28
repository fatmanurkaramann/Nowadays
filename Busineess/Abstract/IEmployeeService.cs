using Busineess.DTOs.Employee;
using Business.Wrappers;
using Entities;

namespace Busineess.Abstract
{
    public interface IEmployeeService
    {
        Task<IDataResult<Employee>> AddAsync(CreateEmployeeDto employeeDto);
        Task<IDataResult<Employee>> DeleteAsync(int id);
        Task<IDataResult<Employee>> UpdateAsync(UpdateEmployeeDto employeeDto);
    }
}
