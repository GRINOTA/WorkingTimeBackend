using MediatR;
using WorkingTime.Application.Tasks.Queries.GetTaskList;

namespace WorkingTime.Application.Tasks.Query.GetTaskList
{
    public class GetTaskListQuery : IRequest<TaskListVm>
    {
        public int ExecutorId { get; set; }
        public int ProjectId { get; set; }
    }
}
