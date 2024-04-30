using Microsoft.EntityFrameworkCore;
using WorkingTime.Persistence.EntityTypeConfigurations;
using System.Configuration;
using WorkingTime.Application.Interfaces;
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

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

        protected override void OnModelCreating(ModelBuilder builder)
        {
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
