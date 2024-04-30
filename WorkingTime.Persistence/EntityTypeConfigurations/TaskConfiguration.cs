using Microsoft.EntityFrameworkCore;
using WorkingTime.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = WorkingTime.Domain.Task;

namespace WorkingTime.Persistence.EntityTypeConfigurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("task");

            builder.HasIndex(e => e.ProjectId, "fk_task_project1_idx");

            builder.HasIndex(e => e.SupervisorEmployeeId, "fk_task_supervisor1_idx");

            builder.HasIndex(e => e.EmployeeId, "fk_task_user1_idx");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.EmployeeId).HasColumnName("employee_id");
            builder.Property(e => e.EndTaskTime)
                .HasColumnType("datetime")
                .HasColumnName("end_task_time");
            builder.Property(e => e.ProjectId).HasColumnName("project_id");
            builder.Property(e => e.StartTaskTime)
                .HasColumnType("datetime")
                .HasColumnName("start_task_time");
            builder.Property(e => e.Status)
                .HasDefaultValueSql("'не выполнено'")
                .HasColumnType("enum('не выполнено','в процессе','выполнено')")
                .HasColumnName("status");
            builder.Property(e => e.SupervisorEmployeeId).HasColumnName("supervisor_employee_id");
            builder.Property(e => e.TaskDescription)
                .HasColumnType("text")
                .HasColumnName("task_description");
            builder.Property(e => e.TaskName)
                .HasMaxLength(50)
                .HasColumnName("task_name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            builder.HasOne(d => d.Employee).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_task_user1");

            builder.HasOne(d => d.Project).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_task_project");

            builder.HasOne(d => d.SupervisorEmployee).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.SupervisorEmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_task_supervisor1");
        }
    }
}
