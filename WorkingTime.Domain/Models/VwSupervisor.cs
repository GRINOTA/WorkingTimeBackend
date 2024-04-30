namespace WorkingTime.Domain.Models;

public partial class VwSupervisor
{
    public int EmployeeId { get; set; }

    public int Id { get; set; }

    public string Role { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
}
