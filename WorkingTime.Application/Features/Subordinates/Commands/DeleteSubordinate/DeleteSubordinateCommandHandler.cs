using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Common.Exceptions;
using WorkingTime.Application.Interfaces;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.Subordinates.Commands.DeleteSubordinate
{
    public class DeleteSubordinateCommandHandler : IRequestHandler<DeleteSubordinateCommand>
    {
        private readonly IWorkingTimeDbContext _dbContext;

        public DeleteSubordinateCommandHandler(IWorkingTimeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async System.Threading.Tasks.Task Handle(DeleteSubordinateCommand request, CancellationToken cancellationToken)
        {
            var admin = await _dbContext.Employees
                .Where(admin => admin.Role.ToLower().Trim() == "администратор" && admin.Id == request.AdminId)
                .FirstOrDefaultAsync();

            var entity = await _dbContext.Subordinates.FindAsync(new object[] { request.EmployeeId }, cancellationToken);

            if (admin == null || entity == null)
            {
                throw new NotFoundException(nameof(Supervisor), request.EmployeeId);
            }

            _dbContext.Subordinates.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
