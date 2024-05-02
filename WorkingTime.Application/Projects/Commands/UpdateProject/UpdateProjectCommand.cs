using MediatR;

namespace WorkingTime.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string? ProjectDescription { get; set; }
    }
}
