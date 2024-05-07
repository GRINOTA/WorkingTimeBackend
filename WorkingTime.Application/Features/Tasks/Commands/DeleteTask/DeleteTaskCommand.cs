using MediatR;

namespace WorkingTime.Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommand : IRequest
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
    }
}
