namespace WorkingTime.Domain.Models;

public partial class Supervisor
{
    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<Subordinate> Subordinates { get; set; } = new List<Subordinate>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
