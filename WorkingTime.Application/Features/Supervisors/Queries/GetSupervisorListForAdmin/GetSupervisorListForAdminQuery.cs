using MediatR;

namespace WorkingTime.Application.Features.Supervisors.Queries.GetSupervisorListForAdmin
{
    public class GetSupervisorListForAdminQuery : IRequest<SupervisorListVm>
    {
        public int AdminId { get; set; }
    }
}
