using MediatR;

namespace WorkingTime.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<int>
    {
        public string ProjectName { get; set; }

        public string? ProjectDescription { get; set; }
    }
}
