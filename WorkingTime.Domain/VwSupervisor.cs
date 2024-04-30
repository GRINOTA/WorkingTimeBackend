using System;
using System.Collections.Generic;

namespace WorkingTime.Domain;

public partial class VwSupervisor
{
    public int EmployeeId { get; set; }

    public int Id { get; set; }

    public int RoleId { get; set; }

    public string Surname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
}
