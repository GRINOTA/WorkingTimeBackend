using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Interfaces;

namespace WorkingTime.Application.Projects.Queries.GetProjectList.GetProjectListByExecutorId
{
    public class GetProjectListQueryByExecutorIdHandler : IRequestHandler<GetProjectListByExecutorIdQuery, ProjectListVm>
    {
        private readonly IWorkingTimeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProjectListQueryByExecutorIdHandler(IWorkingTimeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ProjectListVm> Handle(GetProjectListByExecutorIdQuery request, CancellationToken cancellationToken)
        {
            var projectsQuery = await _dbContext.Projects
                .Where(project => project.Tasks
                    .Where(t => t.ProjectId == project.Id)
                    .Select(t => t.ExecutorId)
                    .FirstOrDefault() == request.ExecutorId)
                .ProjectTo<ProjectLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ProjectListVm { Projects = projectsQuery };
        }
    }
}
