using MediatR;

namespace WorkingTime.Application.Features.WorkingSession.Commands.DeleteWorkSession
{
    public class DeleteWorkSessionCommand : IRequest
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public int ExecutorId { get; set; }
    }
}
