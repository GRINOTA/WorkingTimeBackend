using MediatR;

namespace WorkingTime.Application.Features.Employees.Queries.GetEmployeeDetailForAdmin
{
    public class GetEmployeeDetailForAdminQuery : IRequest<EmployeeDetailVm>
    {
        public int AdminId { get; set; }
        public int Id { get; set; }
    }
}
