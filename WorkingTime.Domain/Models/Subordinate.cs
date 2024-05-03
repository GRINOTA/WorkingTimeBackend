namespace WorkingTime.Domain.Models;
public partial class Subordinate
{
    public int EmployeeId { get; set; }

    public int SupervisorEmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Supervisor SupervisorEmployee { get; set; } = null!;
}
