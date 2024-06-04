using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Interfaces;

namespace WorkingTime.Application.Features.Projects.Queries.GetProjectTimeList
{
    public class GetProjectTimeListQueryHandler : IRequestHandler<GetProjectTimeListQuery, ProjectTimeVm>
    {
        private readonly IWorkingTimeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProjectTimeListQueryHandler(IWorkingTimeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProjectTimeVm> Handle(GetProjectTimeListQuery request, CancellationToken cancellationToken)
        {
            var projectsQuery = await _dbContext.Projects
                .Where(project => project.Tasks
                    .Where(t => t.ProjectId == project.Id)
                    .Select(t => t.ExecutorId)
                    .FirstOrDefault() == request.ExecutorId)
                .ProjectTo<ProjectTimeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ProjectTimeVm { ProjectTimeList = projectsQuery };
        }
    }
}
