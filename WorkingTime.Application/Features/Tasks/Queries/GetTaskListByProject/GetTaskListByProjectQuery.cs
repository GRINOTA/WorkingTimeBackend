using MediatR;

namespace WorkingTime.Application.Features.Tasks.Queries.GetTaskListByProject
{
    public class GetTaskListByProjectQuery : IRequest<TaskListProjectVm>
    {
        public int ExecutorId { get; set; }
        public string? Status { get; set; }

    }
}
