using MediatR;

namespace WorkingTime.Application.Features.Supervisors.Commands.CreateSupervisor
{
    public class CreateSupervisorCommand : IRequest<int>
    {
        public int AdminId { get; set; }
        public int EmployeeId { get; set; }
    }
}
