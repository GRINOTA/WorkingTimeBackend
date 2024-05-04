using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Common.Exceptions;
using WorkingTime.Application.Interfaces;

namespace WorkingTime.Application.Tasks.Queries.GetTaskDetail.GetTaskDetailForCreator
{
    public class GetTaskDetailForCreatorQueryHandler : IRequestHandler<GetTaskDetailForCreatorQuery, TaskDetailForCreatorVm>
    {
        private readonly IWorkingTimeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskDetailForCreatorQueryHandler(IWorkingTimeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TaskDetailForCreatorVm> Handle(GetTaskDetailForCreatorQuery request, CancellationToken cancellationToken)
        {
            var task = await _dbContext.Tasks
                .Join(_dbContext.Projects,
                    t => t.ProjectId,
                    p => p.Id,
                    (t, p) => new
                    {
                        t.Id,
                        CreatorId = p.SupervisorEmployeeId
                    })
                .Where(task => task.Id == request.Id).FirstOrDefaultAsync();

            var taskDetail = await _dbContext.VwProjectsTasks
                .FirstOrDefaultAsync(task => task.Id == request.Id, cancellationToken);

            if (taskDetail == null || task.CreatorId != request.CreatorId || task == null)
            {
                throw new NotFoundException(nameof(Task), request.Id);
            }

            return _mapper.Map<TaskDetailForCreatorVm>(taskDetail);
        }
    }
}
