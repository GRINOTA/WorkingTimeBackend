using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Common.Exceptions;
using WorkingTime.Application.Interfaces;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.WorkingSession.Commands.DeleteWorkSession
{
    public class DeleteWorkSessionCommandHandler : IRequestHandler<DeleteWorkSessionCommand>
    {
        private readonly IWorkingTimeDbContext _dbContext;

        public DeleteWorkSessionCommandHandler(IWorkingTimeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async System.Threading.Tasks.Task Handle(DeleteWorkSessionCommand request, CancellationToken cancellationToken)
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

            var workingSession = await _dbContext.WorkingSessions.FindAsync(new object[] { workingSessionEntity.Id }, cancellationToken);

            if (workingSession == null)
            {
                throw new NotFoundException(nameof(WorkingSession), request.Id);
            }

            _dbContext.WorkingSessions.Remove(workingSession);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
