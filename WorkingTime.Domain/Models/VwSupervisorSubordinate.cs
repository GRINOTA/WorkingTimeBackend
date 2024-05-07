namespace WorkingTime.Domain.Models;

public partial class VwSupervisorSubordinate
{
    public int SubordinateId { get; set; }

    public int SupervisorId { get; set; }

    public string SubordinateSurname { get; set; } = null!;

    public string SubordinateFirstName { get; set; } = null!;

    public string? SubordinatePatronymic { get; set; }

    public string SupervisorSurname { get; set; } = null!;

    public string SupervisoFirstName { get; set; } = null!;

    public string? SupervisorPatronymic { get; set; }
}
