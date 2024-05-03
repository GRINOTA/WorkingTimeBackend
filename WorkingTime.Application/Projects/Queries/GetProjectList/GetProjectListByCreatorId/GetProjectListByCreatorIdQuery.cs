using MediatR;

namespace WorkingTime.Application.Projects.Queries.GetProjectList.GetProjectListByCreatorId
{
    public class GetProjectListByCreatorIdQuery : IRequest<ProjectListVm>
    {
        public int CreatorId { get; set; }
    }
}
