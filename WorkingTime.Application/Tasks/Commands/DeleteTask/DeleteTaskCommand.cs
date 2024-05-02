using MediatR;

namespace WorkingTime.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommand : IRequest
    {
        public int Id { get; set; }
        public int SupervisorId { get; set; }
    }
}
