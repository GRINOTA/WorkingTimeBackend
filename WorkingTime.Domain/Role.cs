﻿using System;
using System.Collections.Generic;

namespace WorkingTime.Domain;

public partial class Role
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
