using MediatR;
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
            var entity = await _dbContext.Tasks.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.SupervisorId == request.SupervisorId)
            {
                throw new NotFoundException(nameof(Task), request.Id);
            }

            _dbContext.Tasks.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
