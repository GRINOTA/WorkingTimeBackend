using Microsoft.AspNetCore.Mvc;
using WorkingTime.Application.Features.Subordinates.Queries.GetSubordinatesList;
using WorkingTime.Application.Features.Subordinates.Commands.CreateSubordinate;
using WorkingTime.Application.Features.Subordinates.Commands.DeleteSubordinate;
using WorkingTime.Application.Features.Subordinates.Queries.GetSubordinatesList.GetAllSubordinatesForAdmin;
using WorkingTime.Application.Features.Subordinates.Queries.GetSubordinatesList.GetSubordinatesForSupervisor;

namespace WorkingTime.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SubordinateController : BaseController
    {
        [HttpGet("get-for-admin")]
        public async Task<ActionResult<SubordinatesListVm>> GetAll([FromQuery] int adminId)
        {
            var query = new GetAllSubordinatesListForAdminQuery
            {
                AdminId = adminId
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("get-for-supervisor")]
        public async Task<ActionResult<SubordinatesListVm>> GetForSupervisor([FromQuery] int supervisorId)
        {
            var query = new GetSubordinatesListForSupervisorQuery
            {
                SupervisorId = supervisorId
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> Create(
            [FromQuery] int adminId, 
            [FromQuery] int employeeId, 
            [FromQuery] int supervisorId)
        {
            var command = new CreateSubordinateCommand
            {
                AdminId = adminId,
                EmployeeId = employeeId,
                Supervisorid = supervisorId
            };

            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id, [FromQuery] int adminId)
        {
            var command = new DeleteSubordinateCommand
            {
                AdminId = adminId,
                EmployeeId = id
            };

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
