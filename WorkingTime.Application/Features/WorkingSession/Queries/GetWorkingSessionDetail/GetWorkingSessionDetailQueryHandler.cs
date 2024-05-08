using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Common.Exceptions;
using WorkingTime.Application.Interfaces;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.WorkingSession.Queries.GetWorkingSessionDetail
{
    public class GetWorkingSessionDetailQueryHandler : IRequestHandler<GetWorkingSessionDetailQuery, VwWorkingSessionEmployee>
    {
        private readonly IWorkingTimeDbContext _dbContext;

        public GetWorkingSessionDetailQueryHandler(IWorkingTimeDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<VwWorkingSessionEmployee> Handle(GetWorkingSessionDetailQuery request, CancellationToken cancellationToken)
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

            Domain.Models.WorkingSession? workingSessionEntity = null;

            if (creator != null)
            {
                workingSessionEntity = await _dbContext.WorkingSessions
                    .Where(ws => ws.EmployeeId == creator.EmployeeId && ws.Id == request.Id)
                    .FirstOrDefaultAsync(cancellationToken);
            }

            if (executor != null)
            {
                workingSessionEntity = await _dbContext.WorkingSessions
                   .Where(ws => ws.EmployeeId == executor.EmployeeId && ws.Id == request.Id)
                   .FirstOrDefaultAsync(cancellationToken);
            }


            if (workingSessionEntity == null)
            {
                throw new NotFoundException(nameof(WorkingSession), request.Id);
            }

            var workingSession = await _dbContext.VwWorkingSessionEmployees
                .Where(ws => ws.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            return workingSession == null ? throw new NotFoundException(nameof(VwWorkingSessionEmployee), request.Id) : workingSession;
        }
    }
}
