using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Common.Exceptions;
using WorkingTime.Application.Interfaces;
using Task = WorkingTime.Domain.Models.Task;

namespace WorkingTime.Application.Tasks.Queries.GetTaskDetail
{
    public class GetTaskDetailQueryHandler : IRequestHandler<GetTaskDetailQuery, TaskDetailVm>
    {
        private readonly IWorkingTimeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskDetailQueryHandler(IWorkingTimeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async System.Threading.Tasks.Task<TaskDetailVm> Handle(GetTaskDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.VwProjectsTasks
                .Join(_dbContext.Tasks,
                vt => vt.Id,
                t => t.Id,
                (vt, t) => new
                {
                    vt.Id,
                    t.ExecutorId,
                    vt.ProjectName,
                    vt.TaskName,
                    vt.TaskDescription,
                    vt.Deadline,
                    vt.Status,
                    vt.StartTask,
                    vt.EndTask,
                    vt.CreatorSurname,
                    vt.CreatorFirstName,
                    vt.CreatorPatronymic
                })
                .FirstOrDefaultAsync(task => task.Id == request.Id, cancellationToken);

            if (entity == null || entity.ExecutorId != request.ExecutorId)
            {
                throw new NotFoundException(nameof(Task), request.Id);
            }

            return _mapper.Map<TaskDetailVm>(entity);
        }
    }
}
