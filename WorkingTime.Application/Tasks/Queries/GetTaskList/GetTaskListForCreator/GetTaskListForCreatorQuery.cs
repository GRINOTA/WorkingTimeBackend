using MediatR;

namespace WorkingTime.Application.Tasks.Queries.GetTaskList.GetTaskListForCreator
{
    public class GetTaskListForCreatorQuery : IRequest<TaskListVm>
    {
        public int CreatorId { get; set; }
        public int? ProjectId { get; set; }
    }
}
