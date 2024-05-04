using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Common.Exceptions;
using WorkingTime.Application.Interfaces;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IWorkingTimeDbContext _dbContext;

        public UpdateProjectCommandHandler(IWorkingTimeDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }
        public async System.Threading.Tasks.Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = 
                await _dbContext.Projects.FirstOrDefaultAsync(project => project.Id == request.Id, cancellationToken);

            if (entity == null || entity.SupervisorEmployeeId != request.CreatorId)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            if(request.ProjectName != null)
                entity.ProjectName = request.ProjectName;

            if(request.ProjectDescription != null)
                entity.ProjectDescription = request.ProjectDescription;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
