using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Common.Exceptions;
using WorkingTime.Application.Features.Tasks.Queries.GetTaskList;
using WorkingTime.Application.Interfaces;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.Tasks.Queries.GetTaskListByProject
{
    public class GetTaskListByProjectQueryHandler : IRequestHandler<GetTaskListByProjectQuery, TaskListProjectVm>
    {

        private readonly IWorkingTimeDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetTaskListByProjectQueryHandler(IWorkingTimeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TaskListProjectVm> Handle(GetTaskListByProjectQuery request, CancellationToken cancellationToken)
        {
            var projectQuery = await _dbContext.Projects
                .Include(p => p.Tasks)
                .Where(p => p.Tasks.Any(t => t.ExecutorId == request.ExecutorId && t.Status == request.Status))
                .Select(p => new Project
                {
                    ProjectName = p.ProjectName,
                    Tasks = p.Tasks.Where(task => task.ExecutorId == request.ExecutorId && task.Status == request.Status).ToList()
                })
                .ProjectTo<TaskProjectLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (projectQuery == null)
            {
                throw new NotFoundException(nameof(Project), request.ExecutorId);
            }

            return new TaskListProjectVm { Tasks = projectQuery };
        }
    }
}
