namespace WorkingTime.Domain.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Role { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Subordinate? Subordinate { get; set; }

    public virtual Supervisor? Supervisor { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual ICollection<WorkingSession> WorkingSessions { get; set; } = new List<WorkingSession>();
}
