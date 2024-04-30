using WorkingTime.Domain;
using Microsoft.EntityFrameworkCore;
using Task = WorkingTime.Domain.Task;


namespace WorkingTime.Application
{
    public interface IWorkingTimeDbContext
    {
        DbSet<Employee> Employees { get; set; }

        DbSet<Project> Projects { get; set; }

        DbSet<Role> Roles { get; set; }

        DbSet<Supervisor> Supervisors { get; set; }

        DbSet<Task> Tasks { get; set; }

        DbSet<VwSupervisor> VwSupervisors { get; set; }

        DbSet<WorkingSession> WorkingSessions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
