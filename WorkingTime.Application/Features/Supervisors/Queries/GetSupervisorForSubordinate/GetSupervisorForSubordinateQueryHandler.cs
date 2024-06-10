using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Interfaces;

namespace WorkingTime.Application.Features.Supervisors.Queries.GetSupervisorForSubordinate
{
    public class GetSupervisorForSubordinateQueryHandler : IRequestHandler<GetSupervisorForSubordinateQuery, SupervisorForSubordinateVm>
    {
        private readonly IWorkingTimeDbContext _workingTimeDbContext;
        private readonly IMapper _mapper;
        public GetSupervisorForSubordinateQueryHandler(IWorkingTimeDbContext workingTimeDbContext, IMapper mapper)
        {
            _workingTimeDbContext = workingTimeDbContext;
            _mapper = mapper;
        }

        public async Task<SupervisorForSubordinateVm> Handle(GetSupervisorForSubordinateQuery request, CancellationToken cancellationToken)
        {
            var supervisor = await _workingTimeDbContext.VwSupervisorSubordinates
                .Where(ss => ss.SubordinateId == request.SubordinateId)
                .FirstOrDefaultAsync();

            return _mapper.Map<SupervisorForSubordinateVm>(supervisor);

        }
    }
}
