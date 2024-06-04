using MediatR;

namespace WorkingTime.Application.Features.Projects.Queries.GetProjectTimeList
{
    public class GetProjectTimeListQuery: IRequest<ProjectTimeVm>
    {
        public int ExecutorId { get; set; }
    }
}
