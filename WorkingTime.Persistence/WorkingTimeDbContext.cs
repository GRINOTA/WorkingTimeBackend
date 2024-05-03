using Microsoft.EntityFrameworkCore;
using WorkingTime.Persistence.EntityTypeConfigurations;
using System.Configuration;
using WorkingTime.Application.Interfaces;
using System.Reflection.Emit;
using WorkingTime.Domain.Models;

namespace WorkingTime.Persistence
{
    public class WorkingTimeDbContext : DbContext, IWorkingTimeDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Domain.Models.Task> Tasks { get; set; }
        public DbSet<VwSupervisor> VwSupervisors { get; set; }
        public DbSet<WorkingSession> WorkingSessions { get; set; }
        public DbSet<VwProjectsTask> VwProjectsTasks { get; set; }
        public DbSet<VwWorkingSessionEmployee> VwWorkingSessionEmployees { get; set; }
        public DbSet<Subordinate> Subordinates { get; set; }
        public DbSet<VwSupervisorSubordinate> VwSupervisorSubordinates { get; set; }

        public WorkingTimeDbContext(DbContextOptions<WorkingTimeDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new ProjectConfiguration());
            builder.ApplyConfiguration(new SupervisorConfiguration());
            builder.ApplyConfiguration(new TaskConfiguration());
            builder.ApplyConfiguration(new VwSupervisorConfiguration());
            builder.ApplyConfiguration(new WorkingSessionConfiguration());
            builder.ApplyConfiguration(new VwProjectsTaskConfiguration());
            builder.ApplyConfiguration(new VwWorkingSessionEmployeeConfiguration());
            builder.ApplyConfiguration(new SubordinateConfiguration());
            builder.ApplyConfiguration(new VwSupervisorSubordinateConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
