using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Common.Exceptions;
using WorkingTime.Application.Interfaces;
using Task = WorkingTime.Domain.Models.Task;

namespace WorkingTime.Application.Tasks.Queries.GetTaskDetail.GetTaskDetailForExecutor
{
    public class GetTaskDetailForExecutorQueryHandler : IRequestHandler<GetTaskDetailForExecutorQuery, TaskDetailForExecutorVm>
    {
        private readonly IWorkingTimeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskDetailForExecutorQueryHandler(IWorkingTimeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TaskDetailForExecutorVm> Handle(GetTaskDetailForExecutorQuery request, CancellationToken cancellationToken)
        {
            var task = await _dbContext.Tasks.Where(task => task.Id == request.Id).FirstOrDefaultAsync();

            var taskDetail = await _dbContext.VwProjectsTasks
                .FirstOrDefaultAsync(task => task.Id == request.Id, cancellationToken);

            if (taskDetail == null || task.ExecutorId != request.ExecutorId || task == null)
            {
                throw new NotFoundException(nameof(Task), request.Id);
            }

            return _mapper.Map<TaskDetailForExecutorVm>(taskDetail);
        }
    }
}
