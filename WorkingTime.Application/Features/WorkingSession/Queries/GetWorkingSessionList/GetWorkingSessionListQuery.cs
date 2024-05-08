using MediatR;

namespace WorkingTime.Application.Features.WorkingSession.Queries.GetWorkingSessionList
{
    public class GetWorkingSessionListQuery : IRequest<WorkingSessionListVm>
    {
        public int CreatorId { get; set; }
        public int ExecutorId { get; set; }
    }
}
