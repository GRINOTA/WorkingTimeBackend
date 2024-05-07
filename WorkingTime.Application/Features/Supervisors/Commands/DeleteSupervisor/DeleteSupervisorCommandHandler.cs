using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Common.Exceptions;
using WorkingTime.Application.Interfaces;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.Supervisors.Commands.DeleteSupervisor
{
    public class DeleteSupervisorCommandHandler : IRequestHandler<DeleteSupervisorCommand>
    {
        private readonly IWorkingTimeDbContext _dbContext;
        public DeleteSupervisorCommandHandler(IWorkingTimeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async System.Threading.Tasks.Task Handle(DeleteSupervisorCommand request, CancellationToken cancellationToken)
        {
            var admin = await _dbContext.Employees
                .Where(admin => admin.Role.ToLower().Trim() == "администратор" && admin.Id == request.AdminId)
                .FirstOrDefaultAsync();

            var supervisor = await _dbContext.Supervisors.FindAsync(new object[] { request.EmployeeId }, cancellationToken);

            if (supervisor == null || admin == null)
            {
                throw new NotFoundException(nameof(Supervisor), request.EmployeeId);
            }

            _dbContext.Supervisors.Remove(supervisor);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
