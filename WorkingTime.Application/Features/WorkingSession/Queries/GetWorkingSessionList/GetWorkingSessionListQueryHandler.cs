using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Common.Exceptions;
using WorkingTime.Application.Interfaces;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.WorkingSession.Queries.GetWorkingSessionList
{
    public class GetWorkingSessionListQueryHandler : IRequestHandler<GetWorkingSessionListQuery, WorkingSessionListVm>
    {
        private readonly IWorkingTimeDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetWorkingSessionListQueryHandler(IWorkingTimeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<WorkingSessionListVm> Handle(GetWorkingSessionListQuery request, CancellationToken cancellationToken)
        {
            var creator = await _dbContext.Supervisors
                .Where(s => s.EmployeeId == request.ExecutorId && s.EmployeeId == request.CreatorId)
                .FirstOrDefaultAsync(cancellationToken);

            var executor = await _dbContext.Subordinates
                .Where(s => s.SupervisorEmployeeId == request.CreatorId && s.EmployeeId == request.ExecutorId)
                .FirstOrDefaultAsync(cancellationToken);

            if (creator == null && executor == null)
            {
                throw new NotFoundException(nameof(Supervisor), request.CreatorId);
            }

            var workingSessions = await _dbContext.WorkingSessions
                .Where(ws => ws.EmployeeId == request.ExecutorId)
                .ProjectTo<WorkingSessionLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new WorkingSessionListVm { WorkingSessionList = workingSessions };
        }
    }
}
