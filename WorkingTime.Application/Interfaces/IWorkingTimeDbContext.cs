using Microsoft.EntityFrameworkCore;
using Task = WorkingTime.Domain.Models.Task;
using WorkingTime.Domain.Models;


namespace WorkingTime.Application.Interfaces
{
    public interface IWorkingTimeDbContext
    {
        DbSet<Employee> Employees { get; set; }

        DbSet<Project> Projects { get; set; }

        DbSet<Supervisor> Supervisors { get; set; }

        DbSet<Task> Tasks { get; set; }

        DbSet<VwSupervisor> VwSupervisors { get; set; }

        DbSet<WorkingSession> WorkingSessions { get; set; }

        DbSet<VwProjectsTask> VwProjectsTasks { get; set; }

        DbSet<VwWorkingSessionEmployee> VwWorkingSessionEmployees { get; set; }

        DbSet<Subordinate> Subordinates { get; set; }

        DbSet<VwSupervisorSubordinate> VwSupervisorSubordinates { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
