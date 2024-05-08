using MediatR;

namespace WorkingTime.Application.Features.WorkingSession.Commands.CreateWorkSession
{
    public class CreateWorkSessionCommand : IRequest<int>
    {
        public int ExecutorId { get; set; }
        public DateTime StartWorkingDay { get; set; }
        public DateTime? EndWorkingDay { get; set; }
    }
}
