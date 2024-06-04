using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Interfaces;

namespace WorkingTime.Application.Features.Employees.Queries.GetEmployee.GetEmployeeAuth
{
    public class GetEmployeeAuthQueryHandler : IRequestHandler<GetEmployeeAuthQuery, EmployeeVm>
    {
        private readonly IWorkingTimeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEmployeeAuthQueryHandler(IWorkingTimeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EmployeeVm> Handle(GetEmployeeAuthQuery request, CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employees
                .Where(e => e.Login == request.Login && e.Password == request.Password)
                .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<EmployeeVm>(employee);
        }
    }
}
