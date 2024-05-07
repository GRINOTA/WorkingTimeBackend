using MediatR;

namespace WorkingTime.Application.Features.Projects.Queries.GetProjectList.GetProjectListByExecutorId
{
    public class GetProjectListByExecutorIdQuery : IRequest<ProjectListVm>
    {
        public int ExecutorId { get; set; }
    }
}
