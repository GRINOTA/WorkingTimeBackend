using MediatR;

namespace WorkingTime.Application.Tasks.Queries.GetTaskDetail
{
    public class GetTaskDetailQuery : IRequest<TaskDetailVm>
    {
        public int ExecutorId { get; set; }
        public int Id { get; set; }
    }
}
