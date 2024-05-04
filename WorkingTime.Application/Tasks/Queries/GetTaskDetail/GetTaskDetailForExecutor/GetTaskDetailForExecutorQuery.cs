using MediatR;

namespace WorkingTime.Application.Tasks.Queries.GetTaskDetail.GetTaskDetailForExecutor
{
    public class GetTaskDetailForExecutorQuery : IRequest<TaskDetailForExecutorVm>
    {
        public int ExecutorId { get; set; }
        public int Id { get; set; }
    }
}
