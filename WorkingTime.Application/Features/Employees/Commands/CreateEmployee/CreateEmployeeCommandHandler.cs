using MediatR;
using WorkingTime.Application.Interfaces;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IWorkingTimeDbContext _dbContext;
        public CreateEmployeeCommandHandler(IWorkingTimeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Surname = request.Surname,
                FirstName = request.FirstName,
                Patronymic = request.Patronymic,
                Login = request.Login,
                Password = request.Password,
            };

            await _dbContext.Employees.AddAsync(employee, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return employee.Id;
        }
    }
}
