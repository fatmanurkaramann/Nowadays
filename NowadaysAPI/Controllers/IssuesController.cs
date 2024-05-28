using Busineess.Abstract;
using Busineess.DTOs.Employee;
using Busineess.DTOs.Issue;
using Microsoft.AspNetCore.Mvc;

namespace NowadaysAPI.Controllers
{
    [Route("api/issue-management")]
    [ApiController]
    public class IssuesController(IIssueService issueService) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateIssueDto issue)
        {
            var res = await issueService.AddAsync(issue);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await issueService.DeleteAsync(id);
            return Ok(res);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateIssueDto issue)
        {
            var res = await issueService.UpdateAsync(issue);
            return Ok(res);
        }
        [HttpPost("assign-employee")]
        public async Task<IActionResult> AssignEmployeeToIssue(AssignEmployeeToIssueDto assignEmployeeToIssueDto)
        {
            var res = await issueService.AssignEmployeeToIssue(assignEmployeeToIssueDto);
            return Ok(res);
        }
    }
}
