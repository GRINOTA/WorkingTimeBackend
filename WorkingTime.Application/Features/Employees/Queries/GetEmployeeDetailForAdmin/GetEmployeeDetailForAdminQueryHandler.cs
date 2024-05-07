using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Interfaces;

namespace WorkingTime.Application.Features.Employees.Queries.GetEmployeeDetailForAdmin
{
    public class GetEmployeeDetailForAdminQueryHandler : IRequestHandler<GetEmployeeDetailForAdminQuery, EmployeeDetailVm>
    {
        private readonly IWorkingTimeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEmployeeDetailForAdminQueryHandler(IWorkingTimeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EmployeeDetailVm> Handle(GetEmployeeDetailForAdminQuery request, CancellationToken cancellationToken)
        {
            var subordinateList = await _dbContext.Subordinates
                .Where(s => s.SupervisorEmployeeId == request.Id)
                .ToListAsync(cancellationToken);

            var supervisor = await _dbContext.Supervisors
                .FirstOrDefaultAsync(s => s.Subordinates
                    .FirstOrDefault(su => su.EmployeeId == request.Id).SupervisorEmployeeId == s.EmployeeId);

            var employee = await _dbContext.Employees
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            var result = _mapper.Map<EmployeeDetailVm>(employee);
            result.Subordinates = subordinateList;
            result.Supervisor = supervisor;
            return result;
        }
    }
}
