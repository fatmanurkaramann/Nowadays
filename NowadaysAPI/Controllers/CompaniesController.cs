using Busineess.Abstract;
using Busineess.DTOs.Company;
using Microsoft.AspNetCore.Mvc;

namespace NowadaysAPI.Controllers
{
    [Route("api/company-management")]
    [ApiController]
    public class CompaniesController(ICompanyService companyService) : ControllerBase
    {

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCompanyDto company)
        {
           var res = await companyService.AddAsync(company);
           return Ok(res);
        }
        [HttpDelete("delete-by-id/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await companyService.DeleteAsync(id);
            return Ok(res);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCompanyDto company)
        {
            var res = await companyService.UpdateAsync(company);
            return Ok(res);
        }
    }
}
