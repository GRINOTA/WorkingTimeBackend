using System;
using System.Collections.Generic;

namespace WorkingTime.Domain;

public partial class Task
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int EmployeeId { get; set; }

    public int SupervisorEmployeeId { get; set; }

    public string TaskName { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? TaskDescription { get; set; }

    public DateTime? StartTaskTime { get; set; }

    public DateTime? EndTaskTime { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual Supervisor SupervisorEmployee { get; set; } = null!;
}
