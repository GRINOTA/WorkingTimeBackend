using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Interfaces;

namespace WorkingTime.Application.Features.Tasks.Queries.GetTaskList.GetTaskListForCreator
{
    public class GetTaskListForCreatorQueryHandler : IRequestHandler<GetTaskListForCreatorQuery, TaskListVm>
    {
        private readonly IWorkingTimeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskListForCreatorQueryHandler(IWorkingTimeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TaskListVm> Handle(GetTaskListForCreatorQuery request, CancellationToken cancellationToken)
        {
            var tasksQuery = await _dbContext.Tasks
                .Where(task => task.Project.SupervisorEmployeeId == request.CreatorId)
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
