using MediatR;

namespace WorkingTime.Application.Features.Tasks.Queries.GetTaskDetail.GetTaskDetailForCreator
{
    public class GetTaskDetailForCreatorQuery : IRequest<TaskDetailForCreatorVm>
    {
        public int CreatorId { get; set; }
        public int Id { get; set; }
    }
}
