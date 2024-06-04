using MediatR;
using WorkingTime.Application.Interfaces;

namespace WorkingTime.Application.Features.WorkingSession.Commands.CreateWorkSession
{
    public class CreateWorkSessionCommandHandler : IRequestHandler<CreateWorkSessionCommand, int>
    {
        private readonly IWorkingTimeDbContext _dbContext;

        public CreateWorkSessionCommandHandler(IWorkingTimeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateWorkSessionCommand request, CancellationToken cancellationToken)
        {
            var workingSession = new Domain.Models.WorkingSession
            {
                EmployeeId = request.ExecutorId,
                StartWorkingDay = request.StartWorkingDay,
                State = request.State
            };

            await _dbContext.WorkingSessions.AddAsync(workingSession, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return workingSession.Id;
        }
    }
}
