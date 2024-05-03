namespace WorkingTime.Domain.Models;

public partial class VwProjectsTask
{
    public int Id { get; set; }

    public int CreatorId { get; set; }

    public string ProjectName { get; set; } = null!;

    public string TaskName { get; set; } = null!;

    public string? TaskDescription { get; set; }

    public DateTime Deadline { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? StartTask { get; set; }

    public DateTime? EndTask { get; set; }

    public string CreatorSurname { get; set; } = null!;

    public string CreatorFirstName { get; set; } = null!;

    public string? CreatorPatronymic { get; set; }

    public string ExecutorSurname { get; set; } = null!;

    public string ExecutorFirstName { get; set; } = null!;

    public string? ExecutorPatronymic { get; set; }
}
