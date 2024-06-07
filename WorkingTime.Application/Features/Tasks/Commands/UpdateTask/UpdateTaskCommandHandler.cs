using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Common.Exceptions;
using WorkingTime.Application.Interfaces;
using Task = WorkingTime.Domain.Models.Task;

namespace WorkingTime.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly IWorkingTimeDbContext _dbContext;

        public UpdateTaskCommandHandler(IWorkingTimeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async System.Threading.Tasks.Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
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

            var task = await _dbContext.Tasks.FirstOrDefaultAsync(task => task.Id == request.Id);

            if (task == null
            //|| projectCreator.creatorId != request.CreatorId || projectCreator == null
            )
            {
                throw new NotFoundException(nameof(Task), request.Id);
            }

            if (request.ProjectId != null)
                task.ProjectId = (int)request.ProjectId;

            if (request.ExecutorId != null)
                task.ExecutorId = (int)request.ExecutorId;

            if (request.TaskName != null)
                task.TaskName = request.TaskName;

            if (request.TaskDescription != null)
                task.TaskDescription = request.TaskDescription;

            if (request.Deadline != null)
                task.Deadline = (DateTime)request.Deadline;
            if (request.StartTask != null)
            {
                if (request.StartTask == "null")
                {
                    task.StartTaskTime = null;
                }
                else {
                    if (DateTime.TryParse(request.StartTask, out DateTime date))
                    {
                        task.StartTaskTime = date;
                    }
                    else 
                    {
                        throw new InvalidDataException($"Ошибка в преобразование даты: {request.StartTask}");
                    }
                }
                

            }


            if (request.EndTask != null)
                if (request.EndTask == "null")
                {
                    task.EndTaskTime = null;
                }
                else
                {
                    if (DateTime.TryParse(request.EndTask, out DateTime date))
                    {
                        task.EndTaskTime = date;
                    }
                    else
                    {
                        throw new InvalidDataException($"Ошибка в преобразование даты: {request.EndTask}");
                    }
                }
            if (request.IsChecked != null)
                task.IsChecked = (bool)request.IsChecked;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
