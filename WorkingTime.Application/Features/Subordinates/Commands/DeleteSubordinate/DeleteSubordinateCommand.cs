using MediatR;

namespace WorkingTime.Application.Features.Subordinates.Commands.DeleteSubordinate
{
    public class DeleteSubordinateCommand : IRequest
    {
        public int AdminId { get; set; }
        public int EmployeeId { get; set; }
    }
}
