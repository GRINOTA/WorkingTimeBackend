namespace WorkingTime.Domain.Models;

public partial class Supervisor
{
    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<Subordinate> Subordinates { get; set; } = new List<Subordinate>();
}
