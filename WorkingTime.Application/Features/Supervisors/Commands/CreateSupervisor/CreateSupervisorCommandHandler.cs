using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Common.Exceptions;
using WorkingTime.Application.Interfaces;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.Supervisors.Commands.CreateSupervisor
{
    public class CreateSupervisorCommandHandler : IRequestHandler<CreateSupervisorCommand, int>
    {
        private readonly IWorkingTimeDbContext _dbContext;

        public CreateSupervisorCommandHandler(IWorkingTimeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(CreateSupervisorCommand request, CancellationToken cancellationToken)
        {
            var admin = await _dbContext.Employees
                .Where(admin => admin.Role.ToLower().Trim() == "администратор" && admin.Id == request.AdminId)
                .FirstOrDefaultAsync();

            if (admin == null)
            {
                throw new NotFoundException(nameof(Employee), request.AdminId);
            }

            var supervisor = new Supervisor
            {
                EmployeeId = request.EmployeeId
            };

            await _dbContext.Supervisors.AddAsync(supervisor, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return supervisor.EmployeeId;
        }
    }
}
