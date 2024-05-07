using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Common.Exceptions;
using WorkingTime.Application.Interfaces;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.Supervisors.Queries.GetSupervisorListForAdmin
{
    public class GetSupervisorListForAdminQueryHandler : IRequestHandler<GetSupervisorListForAdminQuery, SupervisorListVm>
    {
        private readonly IWorkingTimeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSupervisorListForAdminQueryHandler(IWorkingTimeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SupervisorListVm> Handle(GetSupervisorListForAdminQuery request, CancellationToken cancellationToken)
        {
            var admin = await _dbContext.Employees
               .Where(admin => admin.Role.ToLower().Trim() == "администратор" && admin.Id == request.AdminId)
               .FirstOrDefaultAsync();

            if (admin == null)
            {
                throw new NotFoundException(nameof(Employee), request.AdminId);
            }

            var supervisors = await _dbContext.VwSupervisors
                .ProjectTo<SupervisorLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new SupervisorListVm { SupervisorsList = supervisors };
        }
    }
}
