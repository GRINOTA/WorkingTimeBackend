using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Common.Exceptions;
using WorkingTime.Application.Interfaces;
using Task = WorkingTime.Domain.Models.Task;

namespace WorkingTime.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly IWorkingTimeDbContext _dbContext;

        public UpdateTaskCommandHandler(IWorkingTimeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async System.Threading.Tasks.Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Tasks.FirstOrDefaultAsync(task => task.Id == request.Id);

            if (entity == null || entity.SupervisorId != request.SupervisorId)
            {
                throw new NotFoundException(nameof(Task), request.Id);
            }

            entity.SupervisorId = request.SupervisorId;
            entity.ProjectId = request.ProjectId;
            entity.ExecutorId = request.ExecutorId;
            entity.TaskName = request.TaskName;
            entity.TaskDescription = request.TaskDescription;
            entity.Deadline = request.Deadline;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
