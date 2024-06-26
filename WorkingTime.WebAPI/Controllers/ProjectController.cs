﻿using Microsoft.AspNetCore.Mvc;
using WorkingTime.Application.Features.Projects.Queries.GetProjectList;
using WorkingTime.Application.Features.Projects.Commands.CreateProject;
using WorkingTime.Application.Features.Projects.Commands.DeleteProject;
using WorkingTime.Application.Features.Projects.Commands.UpdateProject;
using WorkingTime.Application.Features.Projects.Queries.GetProjectList.GetProjectListByCreatorId;
using WorkingTime.Application.Features.Projects.Queries.GetProjectList.GetProjectListByExecutorId;
using WorkingTime.Application.Features.Projects.Queries.GetProjectTimeList;

namespace WorkingTime.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : BaseController
    {
        [HttpGet("list-time-executor")]
        public async Task<ActionResult<ProjectListVm>> GetListProjectTime([FromQuery] int executorId)
        {
            var query = new GetProjectTimeListQuery
            {
                ExecutorId = executorId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("list-by-executor")]
        public async Task<ActionResult<ProjectListVm>> GetListByExecutorId([FromQuery] int executorId)
        {
            var query = new GetProjectListByExecutorIdQuery
            {
                ExecutorId = executorId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("list-by-creator")]
        public async Task<ActionResult<ProjectListVm>> GetListByCreatorId([FromQuery] int creatorId)
        {
            var query = new GetProjectListByCreatorIdQuery
            {
                CreatorId = creatorId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> Create([FromQuery] int creatorId, [FromQuery] string name, [FromQuery] string? description)
        {
            var command = new CreateProjectCommand
            {
                CreatorId = creatorId,
                ProjectName = name,
                ProjectDescription = description
            };
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromQuery] int creatorId, [FromQuery] string? name, [FromQuery] string? description)
        {
            var command = new UpdateProjectCommand
            {
                Id = id,
                CreatorId = creatorId,
                ProjectName = name,
                ProjectDescription = description
            };

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id, [FromQuery] int creatorId)
        {
            var command = new DeleteProjectCommand
            {
                Id = id,
                CreatorId = creatorId
            };

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
