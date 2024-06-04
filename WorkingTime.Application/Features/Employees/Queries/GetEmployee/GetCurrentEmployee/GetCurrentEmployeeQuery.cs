using MediatR;

namespace WorkingTime.Application.Features.Employees.Queries.GetEmployee.GetCurrentEmployee
{
    public class GetCurrentEmployeeQuery : IRequest<EmployeeVm>
    {
        public int Id { get; set; }
    }
}
