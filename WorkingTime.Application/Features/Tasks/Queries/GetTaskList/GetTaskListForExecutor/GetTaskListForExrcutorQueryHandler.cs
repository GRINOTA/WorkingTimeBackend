using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Interfaces;

namespace WorkingTime.Application.Features.Tasks.Queries.GetTaskList.GetTaskListForExecutor
{
    public class GetTaskListForExrcutorQueryHandler : IRequestHandler<GetTaskListForExecutorQuery, TaskListVm>
    {
        private readonly IWorkingTimeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskListForExrcutorQueryHandler(IWorkingTimeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TaskListVm> Handle(GetTaskListForExecutorQuery request, CancellationToken cancellationToken)
        {
            var tasksQuery = await _dbContext.Tasks
                .Where(task => task.ExecutorId == request.ExecutorId)
                .ProjectTo<TaskLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (request.ProjectId != null)
            {
                tasksQuery = tasksQuery.Where(task => task.ProjectId == request.ProjectId).ToList();
            }

            return new TaskListVm { Tasks = tasksQuery };
        }
    }
}
