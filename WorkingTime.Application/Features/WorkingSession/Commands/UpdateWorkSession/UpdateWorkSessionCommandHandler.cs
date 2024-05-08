using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Common.Exceptions;
using WorkingTime.Application.Interfaces;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.WorkingSession.Commands.UpdateWorkSession
{
    public class UpdateWorkSessionCommandHandler : IRequestHandler<UpdateWorkSessionCommand>
    {

        private readonly IWorkingTimeDbContext _dbContext;
        public UpdateWorkSessionCommandHandler(IWorkingTimeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async System.Threading.Tasks.Task Handle(UpdateWorkSessionCommand request, CancellationToken cancellationToken)
        {
            var workingSession =
                await _dbContext.WorkingSessions.FirstOrDefaultAsync(ws => ws.Id == request.Id, cancellationToken);

            if (workingSession == null || workingSession.EmployeeId != request.ExecutorId)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            if (request.StartWorkingDay != null)
                workingSession.StartWorkingDay = (DateTime)request.StartWorkingDay;

            if (request.EndWorkingDay != null)
                workingSession.EndWorkingDay = (DateTime)request.EndWorkingDay;

            if (request.TotalBreakTime != null)
                workingSession.TotalBreakTime = request.TotalBreakTime;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
