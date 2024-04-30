using System;
using System.Collections.Generic;

namespace WorkingTime.Domain;

public partial class Supervisor
{
    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
