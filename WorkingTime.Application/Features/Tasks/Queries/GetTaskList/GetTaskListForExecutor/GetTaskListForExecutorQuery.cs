using MediatR;

namespace WorkingTime.Application.Features.Tasks.Queries.GetTaskList.GetTaskListForExecutor
{
    public class GetTaskListForExecutorQuery : IRequest<TaskListVm>
    {
        public int ExecutorId { get; set; }
        public int? ProjectId { get; set; }
    }
}
