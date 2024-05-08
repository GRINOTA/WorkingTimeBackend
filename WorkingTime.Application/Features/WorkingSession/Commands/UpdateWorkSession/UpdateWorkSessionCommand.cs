using MediatR;

namespace WorkingTime.Application.Features.WorkingSession.Commands.UpdateWorkSession
{
    public class UpdateWorkSessionCommand : IRequest
    {
        public int Id { get; set; }
        public int ExecutorId { get; set; }
        public DateTime? StartWorkingDay { get; set; }
        public DateTime? EndWorkingDay { get; set; }
        public int? TotalBreakTime { get; set; }

    }
}
