using MediatR;

namespace WorkingTime.Application.Features.Subordinates.Commands.CreateSubordinate
{
    public class CreateSubordinateCommand : IRequest<int>
    {
        public int AdminId { get; set; }
        public int EmployeeId { get; set; }
        public int Supervisorid { get; set; }
    }
}
