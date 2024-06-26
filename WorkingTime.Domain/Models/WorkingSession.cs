﻿namespace WorkingTime.Domain.Models;

public partial class WorkingSession
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public DateTime StartWorkingDay { get; set; }

    public DateTime? EndWorkingDay { get; set; }

    public int? TotalWorkingTime { get; set; }

    public bool? State { get; set; }

    public int? CompletedTaskNumber { get; set; }

    public decimal? PerformanceEvaluation { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
