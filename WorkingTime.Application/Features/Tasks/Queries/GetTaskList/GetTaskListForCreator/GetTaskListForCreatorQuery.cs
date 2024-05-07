using MediatR;

namespace WorkingTime.Application.Features.Tasks.Queries.GetTaskList.GetTaskListForCreator
{
    public class GetTaskListForCreatorQuery : IRequest<TaskListVm>
    {
        public int CreatorId { get; set; }
        public int? ProjectId { get; set; }
    }
}
