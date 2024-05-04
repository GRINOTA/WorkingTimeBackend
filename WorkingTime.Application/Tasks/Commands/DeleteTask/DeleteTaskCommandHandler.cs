using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Common.Exceptions;
using WorkingTime.Application.Interfaces;
using Task = WorkingTime.Domain.Models.Task;

namespace WorkingTime.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly IWorkingTimeDbContext _dbContext;
        public DeleteTaskCommandHandler(IWorkingTimeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async System.Threading.Tasks.Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var projectCreator = await _dbContext.Projects
                .Join(
                    _dbContext.Tasks,
                    p => p.Id,
                    t => t.ProjectId,
                    (p, t) => new
                    {
                        taskId = t.Id,
                        creatorId = p.SupervisorEmployeeId
                    })
                .Where(t => t.taskId == request.Id)
                .FirstOrDefaultAsync();

            var task = await _dbContext.Tasks.FindAsync(new object[] { request.Id }, cancellationToken);

            if (task == null || projectCreator.creatorId != request.CreatorId || projectCreator == null)
            {
                throw new NotFoundException(nameof(Task), request.Id);
            }

            _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
