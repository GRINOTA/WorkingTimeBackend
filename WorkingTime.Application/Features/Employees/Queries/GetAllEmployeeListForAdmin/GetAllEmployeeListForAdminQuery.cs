using MediatR;

namespace WorkingTime.Application.Features.Employees.Queries.GetAllEmployeeListForAdmin
{
    public class GetAllEmployeeListForAdminQuery : IRequest<EmployeeListVm>
    {
        public int AdminId { get; set; }
    }
}
