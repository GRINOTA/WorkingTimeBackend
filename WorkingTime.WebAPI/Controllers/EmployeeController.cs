using Microsoft.AspNetCore.Mvc;
using WorkingTime.Application.Features.Employees.Commands.CreateEmployee;
using WorkingTime.Application.Features.Employees.Queries.GetEmployeeDetailForAdmin;
using WorkingTime.Application.Features.Employees.Queries.GetAllEmployeeListForAdmin;
using WorkingTime.Application.Features.Employees.Queries.GetEmployee.GetEmployeeAuth;
using WorkingTime.Application.Features.Employees.Queries.GetEmployee;
using WorkingTime.Application.Features.Employees.Queries.GetEmployee.GetCurrentEmployee;

namespace WorkingTime.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : BaseController
    {
        [HttpGet("auth")]
        public async Task<ActionResult<EmployeeVm>> GetAuth(
            [FromQuery] string login,
            [FromQuery] string password)
        {
            var query = new GetEmployeeAuthQuery
            {
                Login = login,
                Password = password
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("current/{id}")]
        public async Task<ActionResult<EmployeeVm>> GetCurrentEmployee(int id)
        {
            var query = new GetCurrentEmployeeQuery
            {
                Id = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("list-for-admin")]
        public async Task<ActionResult<EmployeeListVm>> GetAllForAdmin([FromQuery] int adminId)
        {
            var query = new GetAllEmployeeListForAdminQuery
            {
                AdminId = adminId
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        // сделать mapper на subordinates и supervisor
        [HttpGet("detail-for-admin/{id}")]
        public async Task<ActionResult<EmployeeListVm>> GetDetailForAdmin(int id, [FromQuery] int adminId)
        {
            var query = new GetEmployeeDetailForAdminQuery
            {
                Id = id,
                AdminId = adminId
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> Create(
            [FromQuery] string surname,
            [FromQuery] string firstName,
            [FromQuery] string? patronymic,
            [FromQuery] string login,
            [FromQuery] string password)
        {
            var command = new CreateEmployeeCommand
            {
                Surname = surname,
                FirstName = firstName,
                Patronymic = patronymic,
                Login = login,
                Password = password
            };

            var id = await Mediator.Send(command);
            return Ok(id);
        }
    }
}
