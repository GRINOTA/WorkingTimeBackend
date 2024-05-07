using MediatR;
using WorkingTime.Application.Common.Exceptions;
using WorkingTime.Application.Interfaces;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IWorkingTimeDbContext _dbContext;

        public DeleteProjectCommandHandler(IWorkingTimeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async System.Threading.Tasks.Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Projects.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.SupervisorEmployeeId != request.CreatorId)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            _dbContext.Projects.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
