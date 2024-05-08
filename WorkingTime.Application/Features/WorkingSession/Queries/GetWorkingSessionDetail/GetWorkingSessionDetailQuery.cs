using MediatR;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.WorkingSession.Queries.GetWorkingSessionDetail
{
    public class GetWorkingSessionDetailQuery : IRequest<VwWorkingSessionEmployee>
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public int ExecutorId { get; set; }
    }
}
