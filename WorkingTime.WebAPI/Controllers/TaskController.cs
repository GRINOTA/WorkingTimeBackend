using Microsoft.AspNetCore.Mvc;
using WorkingTime.Application.Features.Tasks.Queries.GetTaskList.GetTaskListForExecutor;
using WorkingTime.Application.Features.Tasks.Queries.GetTaskList.GetTaskListForCreator;
using WorkingTime.Application.Features.Tasks.Commands.CreateTask;
using WorkingTime.Application.Features.Tasks.Commands.UpdateTask;
using WorkingTime.Application.Features.Tasks.Commands.DeleteTask;
using WorkingTime.Application.Features.Tasks.Queries.GetTaskList;
using WorkingTime.Application.Features.Tasks.Queries.GetTaskDetail.GetTaskDetailForCreator;
using WorkingTime.Application.Features.Tasks.Queries.GetTaskDetail.GetTaskDetailForExecutor;
using WorkingTime.Application.Features.Tasks.Queries.GetTaskListByProject;

namespace WorkingTime.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : BaseController
    {
        [HttpGet("list-for-executor")]
        public async Task<ActionResult<TaskListVm>> GetListForExecutor([FromQuery] int executorId, [FromQuery] int? projectId)
        {
            var query = new GetTaskListForExecutorQuery
            {
                ExecutorId = executorId,
                ProjectId = projectId
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("list-for-executor-project")]
        public async Task<ActionResult<TaskListVm>> GetListForExecutorProject(
            [FromQuery] int executorId, 
            [FromQuery] string? status1,
            [FromQuery] string? status2
            )
        {
            var query = new GetTaskListByProjectQuery
            {
                ExecutorId = executorId,
                Status1 = status1,
                Status2 = status2
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("list-for-creator")]
        public async Task<ActionResult<TaskListVm>> GetListForCreator([FromQuery] int creatorId, [FromQuery] int? projectId)
        {
            var query = new GetTaskListForCreatorQuery
            {
                CreatorId = creatorId,
                ProjectId = projectId
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("detail-for-executor/{id}")]
        public async Task<ActionResult<TaskDetailForExecutorVm>> GetDetailForExecutor(int id, [FromQuery] int executorId)
        {
            var query = new GetTaskDetailForExecutorQuery
            {
                ExecutorId = executorId,
                Id = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("detail-for-creator/{id}")]
        public async Task<ActionResult<TaskDetailForCreatorVm>> GetDetail(int id, [FromQuery] int creatorId)
        {
            var query = new GetTaskDetailForCreatorQuery
            {
                CreatorId = creatorId,
                Id = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> Create(
            [FromQuery] int creatorId,
            [FromQuery] int executorId,
            [FromQuery] int projectId,
            [FromQuery] string name,
            [FromQuery] string? description,
            [FromQuery] DateTime deadline)
        {
            var command = new CreateTaskCommand
            {
                CreatorId = creatorId,
                ExecutorId = executorId,
                ProjectId = projectId,
                TaskName = name,
                TaskDescription = description,
                Deadline = deadline
            };

            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromQuery] int creatorId,
            [FromQuery] int? executorId,
            [FromQuery] int? projectId,
            [FromQuery] string? name,
            [FromQuery] string? description,
            [FromQuery] DateTime? deadline,
            [FromQuery] string? startTask,
            [FromQuery] string? endTask,
            [FromQuery] bool? isChecked)
        {
            var command = new UpdateTaskCommand
            {
                Id = id,
                //CreatorId = creatorId,
                ExecutorId = executorId,
                ProjectId = projectId,
                TaskName = name,
                TaskDescription = description,
                Deadline = deadline,
                StartTask = startTask,
                EndTask = endTask,
                IsChecked = isChecked
            };

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id, [FromQuery] int creatorId)
        {
            var command = new DeleteTaskCommand
            {
                Id = id,
                CreatorId = creatorId
            };

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
