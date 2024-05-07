using MediatR;

namespace WorkingTime.Application.Features.Supervisors.Commands.DeleteSupervisor
{
    public class DeleteSupervisorCommand : IRequest
    {
        public int AdminId { get; set; }
        public int EmployeeId { get; set; }
    }
}
