namespace WorkingTime.Domain.Models;

public partial class Task
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int SupervisorId { get; set; }

    public int ExecutorId { get; set; }

    public string TaskName { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime Deadline { get; set; }

    public string? TaskDescription { get; set; }

    public DateTime? StartTaskTime { get; set; }

    public DateTime? EndTaskTime { get; set; }

    public virtual Employee Executor { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual Supervisor Supervisor { get; set; } = null!;
}
