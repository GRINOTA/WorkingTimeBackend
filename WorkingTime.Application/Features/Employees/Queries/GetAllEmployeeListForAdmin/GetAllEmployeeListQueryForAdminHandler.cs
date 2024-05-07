using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WorkingTime.Application.Common.Exceptions;
using WorkingTime.Application.Interfaces;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.Employees.Queries.GetAllEmployeeListForAdmin
{
    public class GetAllEmployeeListQueryForAdminHandler : IRequestHandler<GetAllEmployeeListForAdminQuery, EmployeeListVm>
    {

        private readonly IWorkingTimeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllEmployeeListQueryForAdminHandler(IWorkingTimeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EmployeeListVm> Handle(GetAllEmployeeListForAdminQuery request, CancellationToken cancellationToken)
        {
            var admin = await _dbContext.Employees
                .Where(admin => admin.Role.ToLower().Trim() == "администратор" && admin.Id == request.AdminId)
                .FirstOrDefaultAsync();

            if (admin == null)
            {
                throw new NotFoundException(nameof(Employee), request.AdminId);
            }

            var employees = await _dbContext.Employees
                .Where(employee => employee.Id != admin.Id)
                .ProjectTo<EmployeeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new EmployeeListVm { AllEmployees = employees };
        }
    }
}
