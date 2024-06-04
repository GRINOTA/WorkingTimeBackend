using Microsoft.AspNetCore.Mvc;
using WorkingTime.Application.Features.WorkingSession.Queries.GetWorkingSessionList;
using WorkingTime.Domain.Models;
using WorkingTime.Application.Features.WorkingSession.Queries.GetWorkingSessionDetail;
using WorkingTime.Application.Features.WorkingSession.Commands.CreateWorkSession;
using WorkingTime.Application.Features.WorkingSession.Commands.UpdateWorkSession;
using WorkingTime.Application.Features.WorkingSession.Commands.DeleteWorkSession;

namespace WorkingTime.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SessionController : BaseController
    {
        [HttpGet("get-list-executor")]
        public async Task<ActionResult<WorkingSessionListVm>> GetList(
            [FromQuery] int executorId,
            [FromQuery] DateTime? dateReport)
        {
            var query = new GetWorkingSessionListForExecutorQuery
            {
                ExecutorId = executorId,
                DateReport = dateReport,
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("get-list-creator")]
        public async Task<ActionResult<WorkingSessionListVm>> GetList(
            [FromQuery] int creatorId,
            [FromQuery] int executorId)
        {
            var query = new GetWorkingSessionListQuery
            {
                CreatorId = creatorId,
                ExecutorId = executorId
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<VwWorkingSessionEmployee>> GetListByExecutorId(
            int id,
            [FromQuery] int creatorId,
            [FromQuery] int executorId)
        {
            var query = new GetWorkingSessionDetailQuery
            {
                Id = id,
                CreatorId = creatorId,
                ExecutorId = executorId
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> Create(
            [FromQuery] int executorId,
            [FromQuery] DateTime startDay
            )
        {
            var command = new CreateWorkSessionCommand
            {
                ExecutorId = executorId,
                StartWorkingDay = startDay
            };

            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromQuery] int executorId,
            [FromQuery] DateTime? startDay,
            [FromQuery] DateTime? endDay,
            [FromQuery] int? totalBreak)
        {
            var command = new UpdateWorkSessionCommand
            {
                Id = id,
                ExecutorId = executorId,
                StartWorkingDay = startDay,
                EndWorkingDay = endDay,
                //TotalBreakTime = totalBreak
            };

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(
            int id,
            [FromQuery] int creatorId,
            [FromQuery] int executorId)
        {
            var command = new DeleteWorkSessionCommand
            {
                Id = id,
                CreatorId = creatorId,
                ExecutorId = executorId
            };

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
