using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Common.Exceptions;
using WorkingTime.Application.Interfaces;

namespace WorkingTime.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
    {
        private readonly IWorkingTimeDbContext _dbContext;
        public CreateTaskCommandHandler(IWorkingTimeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var projectCreator = await _dbContext.Projects
                .Where(p => p.Id == request.ProjectId && p.SupervisorEmployeeId == request.CreatorId)
                .FirstOrDefaultAsync();

            if (projectCreator == null)
            {
                throw new NotFoundException(nameof(Projects), request.ProjectId);
            }

            var task = new Domain.Models.Task
            {
                ProjectId = request.ProjectId,
                ExecutorId = request.ExecutorId,
                TaskName = request.TaskName,
                TaskDescription = request.TaskDescription,
                Deadline = request.Deadline
            };

            await _dbContext.Tasks.AddAsync(task, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return task.Id;
        }
    }
}
