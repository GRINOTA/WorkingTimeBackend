using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Interfaces;

namespace WorkingTime.Application.Features.Subordinates.Queries.GetSubordinatesList.GetSubordinatesForSupervisor
{
    public class GetSubordinatesListForSupervisorQueryHandler : IRequestHandler<GetSubordinatesListForSupervisorQuery, SubordinatesListVm>
    {
        private readonly IWorkingTimeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSubordinatesListForSupervisorQueryHandler(IWorkingTimeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SubordinatesListVm> Handle(GetSubordinatesListForSupervisorQuery request, CancellationToken cancellationToken)
        {
            var subordinatesList = await _dbContext.VwSupervisorSubordinates
                .Where(s => s.SupervisorId == request.SupervisorId)
                .ProjectTo<SubordinateLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new SubordinatesListVm { SubordinatesList = subordinatesList };
        }
    }
}
