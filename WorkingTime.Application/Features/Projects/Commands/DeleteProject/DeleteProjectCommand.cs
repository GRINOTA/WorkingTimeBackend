using MediatR;

namespace WorkingTime.Application.Features.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
    }
}
