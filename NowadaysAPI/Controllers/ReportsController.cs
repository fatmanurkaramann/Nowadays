using Busineess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace NowadaysAPI.Controllers
{
    [Route("api/report-management")]
    [ApiController]
    public class ReportsController(IReportService reportService) : ControllerBase
    {

        [HttpGet("employee-count-report/{companyId}")]
        public async Task<IActionResult> GetProjectsEmployeeCount(int companyId)
        {
            var result = await reportService.GetProjectsEmployeeCount(companyId);
            return Ok(result);
        }

        [HttpGet("issue-count-report/{companyId}")]
        public async Task<IActionResult> GetIssueReport(int companyId)
        {
            var result = await reportService.GetIssueReport(companyId);
            return Ok(result);
        }
    }
}
