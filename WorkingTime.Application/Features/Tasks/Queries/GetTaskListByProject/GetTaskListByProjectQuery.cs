using MediatR;

namespace WorkingTime.Application.Features.Tasks.Queries.GetTaskListByProject
{
    public class GetTaskListByProjectQuery : IRequest<TaskListProjectVm>
    {
        public int ExecutorId { get; set; }
        public string? Status1 { get; set; }
        public string? Status2 { get; set; }

    }
}
