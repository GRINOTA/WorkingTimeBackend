using Microsoft.AspNetCore.Mvc;
using WorkingTime.Application.Features.Supervisors.Queries.GetSupervisorListForAdmin;
using WorkingTime.Application.Features.Supervisors.Commands.CreateSupervisor;
using WorkingTime.Application.Features.Supervisors.Commands.DeleteSupervisor;

namespace WorkingTime.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SupervisorController : BaseController
    {
        [HttpGet("get-for-admin")]
        public async Task<ActionResult<SupervisorListVm>> GetAll([FromQuery] int adminId)
        {
            var query = new GetSupervisorListForAdminQuery
            {
                AdminId = adminId
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> Create([FromQuery] int employeeId, [FromQuery] int adminId)
        {
            var command = new CreateSupervisorCommand
            {
                AdminId = adminId,
                EmployeeId = employeeId
            };

            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id, [FromQuery] int adminId)
        {
            var command = new DeleteSupervisorCommand
            {
                AdminId = adminId,
                EmployeeId = id
            };

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
