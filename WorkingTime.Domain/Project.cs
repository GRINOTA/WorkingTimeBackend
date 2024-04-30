using System;
using System.Collections.Generic;

namespace WorkingTime.Domain;

public partial class Project
{
    public int Id { get; set; }

    public string ProjectName { get; set; } = null!;

    public string? ProjectDescription { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
