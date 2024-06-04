using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Interfaces;

namespace WorkingTime.Application.Features.WorkingSession.Queries.GetWorkingSessionList
{
    public class GetWorkingSessionListForExecuterQueryHandler : IRequestHandler<GetWorkingSessionListForExecutorQuery, WorkingSessionListVm>
    {
        private readonly IWorkingTimeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetWorkingSessionListForExecuterQueryHandler(IWorkingTimeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<WorkingSessionListVm> Handle(GetWorkingSessionListForExecutorQuery request, CancellationToken cancellationToken)
        {
            var sessions = await _dbContext.WorkingSessions
                .Where(ws => ws.EmployeeId == request.ExecutorId)
                .ProjectTo<WorkingSessionLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (request.DateReport != null)
            {
                sessions = sessions.Where(s => s.EndWorkSession.HasValue && s.EndWorkSession.Value.Date == request.DateReport.Value.Date).ToList();
            }

            return new WorkingSessionListVm { WorkingSessionList = sessions };
        }
    }
}
