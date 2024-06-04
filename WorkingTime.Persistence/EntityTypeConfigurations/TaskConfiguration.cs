using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = WorkingTime.Domain.Models.Task;

namespace WorkingTime.Persistence.EntityTypeConfigurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("task");

            builder.HasIndex(e => e.ExecutorId, "fk_task_employee_idx");

            builder.HasIndex(e => e.ProjectId, "fk_task_project_idx");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Deadline)
                .HasColumnType("datetime")
                .HasColumnName("deadline");
            builder.Property(e => e.EndTaskTime)
                .HasColumnType("datetime")
                .HasColumnName("end_task_time");
            builder.Property(e => e.ExecutorId).HasColumnName("executor_id");
            builder.Property(e => e.ProjectId).HasColumnName("project_id");
            builder.Property(e => e.StartTaskTime)
                .HasColumnType("datetime")
                .HasColumnName("start_task_time");
            builder.Property(e => e.Status)
                .HasDefaultValueSql("'не выполнено'")
                .HasColumnType("enum('не выполнено','в процессе','выполнено','просрочено')")
                .HasColumnName("status");
            builder.Property(e => e.TaskDescription)
                .HasColumnType("text")
                .HasColumnName("task_description");
            builder.Property(e => e.TaskName)
                .HasMaxLength(50)
                .HasColumnName("task_name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            builder.Property(e => e.TotalTaskTime).HasColumnName("total_task_time");

            builder.HasOne(d => d.Executor).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ExecutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_task_employee");

            builder.HasOne(d => d.Project).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_task_project");
        }
    }
}
