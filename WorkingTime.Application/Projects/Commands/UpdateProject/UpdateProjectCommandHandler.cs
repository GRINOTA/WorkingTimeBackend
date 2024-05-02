using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
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

            if (entity == null)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            entity.ProjectName = request.ProjectName;
            entity.ProjectDescription = request.ProjectDescription;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
