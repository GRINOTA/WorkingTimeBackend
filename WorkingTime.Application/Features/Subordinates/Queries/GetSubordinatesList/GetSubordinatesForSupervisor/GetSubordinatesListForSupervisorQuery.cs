using MediatR;

namespace WorkingTime.Application.Features.Subordinates.Queries.GetSubordinatesList.GetSubordinatesForSupervisor
{
    public class GetSubordinatesListForSupervisorQuery : IRequest<SubordinatesListVm>
    {
        public int SupervisorId { get; set; }
    }
}
