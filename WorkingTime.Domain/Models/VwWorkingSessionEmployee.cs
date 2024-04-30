namespace WorkingTime.Domain.Models;

public partial class VwWorkingSessionEmployee
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public DateTime StartDay { get; set; }

    public DateTime? EndDay { get; set; }

    public int? TotalWorkingTime { get; set; }

    public int? TotalBreakTime { get; set; }

    public int? CompletedTaskNumber { get; set; }

    public decimal? PerformanceEvaluation { get; set; }
}
