using MediatR;

namespace WorkingTime.Application.Features.WorkingSession.Queries.GetWorkingSessionList
{
    public class GetWorkingSessionListForExecutorQuery: IRequest<WorkingSessionListVm>
    {
        public int ExecutorId { get; set; }
        public DateTime? DateReport { get; set; }
    }
}
