using MediatR;

namespace WorkingTime.Application.Features.Employees.Queries.GetEmployee.GetEmployeeAuth
{
    public class GetEmployeeAuthQuery : IRequest<EmployeeVm>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
