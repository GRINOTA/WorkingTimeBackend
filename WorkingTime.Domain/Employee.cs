using System;
using System.Collections.Generic;

namespace WorkingTime.Domain;

public partial class Employee
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public string Surname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;

    public virtual Supervisor? Supervisor { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual ICollection<WorkingSession> WorkingSessions { get; set; } = new List<WorkingSession>();
}
