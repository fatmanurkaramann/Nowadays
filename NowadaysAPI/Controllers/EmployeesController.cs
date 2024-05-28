using Busineess.Abstract;
using Busineess.DTOs.Employee;
using Microsoft.AspNetCore.Mvc;

namespace NowadaysAPI.Controllers
{
    [Route("api/employee-management")]
    [ApiController]
    public class EmployeesController(IEmployeeService employeeService) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateEmployeeDto company)
        {
            var res = await employeeService.AddAsync(company);
            return Ok(res);
        }

        [HttpDelete("delete-by-id/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await employeeService.DeleteAsync(id);
            return Ok(res);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateEmployeeDto employee)
        {
            var res = await employeeService.UpdateAsync(employee);
            return Ok(res);
        }
    }
}
