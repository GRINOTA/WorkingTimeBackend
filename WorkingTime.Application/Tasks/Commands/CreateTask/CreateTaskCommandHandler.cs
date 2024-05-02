using MediatR;
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
            var task = new Domain.Models.Task
            {
                ProjectId = request.ProjectId,
                ExecutorId = request.ExecutorId,
                SupervisorId = request.SupervisorId,
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
