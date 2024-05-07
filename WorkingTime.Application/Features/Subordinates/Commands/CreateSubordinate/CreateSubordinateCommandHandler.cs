using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Common.Exceptions;
using WorkingTime.Application.Interfaces;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.Subordinates.Commands.CreateSubordinate
{
    public class CreateSubordinateCommandHandler : IRequestHandler<CreateSubordinateCommand, int>
    {
        private readonly IWorkingTimeDbContext _dbContext;
        public CreateSubordinateCommandHandler(IWorkingTimeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateSubordinateCommand request, CancellationToken cancellationToken)
        {
            var admin = await _dbContext.Employees
                .Where(admin => admin.Role.ToLower().Trim() == "администратор" && admin.Id == request.AdminId)
                .FirstOrDefaultAsync();

            if (admin == null)
            {
                throw new NotFoundException(nameof(Employee), request.AdminId);
            }

            var subordinate = new Subordinate
            {
                EmployeeId = request.EmployeeId,
                SupervisorEmployeeId = request.Supervisorid
            };

            await _dbContext.Subordinates.AddAsync(subordinate, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return subordinate.EmployeeId;
        }
    }
}
