using MediatR;

namespace WorkingTime.Application.Projects.Queries.GetProjectList
{
    public class GetProjectListQuery : IRequest<ProjectListVm>
    {
        public int ExecutorId { get; set; }
    }
}
