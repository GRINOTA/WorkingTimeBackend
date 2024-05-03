namespace WorkingTime.Domain.Models;

public partial class Project
{
    public int Id { get; set; }

    public int SupervisorEmployeeId { get; set; }

    public string ProjectName { get; set; } = null!;

    public string? ProjectDescription { get; set; }

    public virtual Supervisor SupervisorEmployee { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
