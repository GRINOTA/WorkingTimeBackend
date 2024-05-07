using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Common.Exceptions;
using WorkingTime.Application.Interfaces;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.Subordinates.Queries.GetSubordinatesList.GetAllSubordinatesForAdmin
{
    public class GetAllSubordinatesLsitForAdminQueryHandler : IRequestHandler<GetAllSubordinatesListForAdminQuery, SubordinatesListVm>
    {
        private readonly IWorkingTimeDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAllSubordinatesLsitForAdminQueryHandler(IWorkingTimeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SubordinatesListVm> Handle(GetAllSubordinatesListForAdminQuery request, CancellationToken cancellationToken)
        {
            var admin = await _dbContext.Employees
               .Where(admin => admin.Role.ToLower().Trim() == "администратор" && admin.Id == request.AdminId)
               .FirstOrDefaultAsync();

            if (admin == null)
            {
                throw new NotFoundException(nameof(Employee), request.AdminId);
            }

            var subordinatesList = await _dbContext.VwSupervisorSubordinates
                .ProjectTo<SubordinateLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new SubordinatesListVm { SubordinatesList = subordinatesList };
        }
    }
}
