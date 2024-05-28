using Busineess.Abstract;
using Busineess.DTOs.Employee;
using Busineess.DTOs.Project;
using Microsoft.AspNetCore.Mvc;

namespace NowadaysAPI.Controllers
{
    [Route("api/project-management")]
    [ApiController]
    public class ProjectsController(IProjectService projectService) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateProjectDto issue)
        {
            var res = await projectService.AddAsync(issue);
            return Ok(res);
        }
        [HttpDelete("delete-by-id/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await projectService.DeleteAsync(id);
            return Ok(res);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateProjectDto issue)
        {
            var res = await projectService.UpdateAsync(issue);
            return Ok(res);
        }
        [HttpPost("assign-employee")]
        public async Task<IActionResult> AssignEmployee(AssignEmployeeToProjectDto assignEmployeeToProjectDto)
        {
            var res = await projectService.AssignEmployeeToProject(assignEmployeeToProjectDto);
            return Ok(res);
        }
    }
}
