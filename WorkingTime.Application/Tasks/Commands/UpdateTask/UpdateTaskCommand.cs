using MediatR;

namespace WorkingTime.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommand : IRequest
    {
        public int Id { get; set; }
        public int SupervisorId { get; set; }
        public int ExecutorId { get; set; }
        public int ProjectId { get; set; }
        public string TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public DateTime Deadline { get; set; }
    }
}
