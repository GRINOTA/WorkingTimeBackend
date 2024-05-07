using MediatR;

namespace WorkingTime.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<int>
    {
        public int CreatorId { get; set; }
        public int ExecutorId { get; set; }
        public int ProjectId { get; set; }
        public string TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public DateTime Deadline { get; set; }

    }
}
