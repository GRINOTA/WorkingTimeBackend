using MediatR;

namespace WorkingTime.Application.Features.Subordinates.Queries.GetSubordinatesList.GetAllSubordinatesForAdmin
{
    public class GetAllSubordinatesListForAdminQuery : IRequest<SubordinatesListVm>
    {
        public int AdminId { get; set; }
    }
}
