using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkingTime.Domain.Models;

namespace WorkingTime.Persistence.EntityTypeConfigurations
{
    internal class WorkingSessionConfiguration : IEntityTypeConfiguration<WorkingSession>
    {
        public void Configure(EntityTypeBuilder<WorkingSession> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("working_session");

            builder.HasIndex(e => e.EmployeeId, "fk_working_session_employee_idx");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.CompletedTaskNumber)
                .HasDefaultValueSql("'0'")
                .HasColumnName("completed_task_number");
            builder.Property(e => e.EmployeeId).HasColumnName("employee_id");
            builder.Property(e => e.EndWorkingDay)
                .HasColumnType("datetime")
                .HasColumnName("end_working_day");
            builder.Property(e => e.PerformanceEvaluation)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("performance_evaluation");
            builder.Property(e => e.StartWorkingDay)
                .HasColumnType("datetime")
                .HasColumnName("start_working_day");
            builder.Property(e => e.State)
                .HasDefaultValueSql("'0'")
                .HasColumnName("state");
            builder.Property(e => e.TotalWorkingTime).HasColumnName("total_working_time");

            builder.HasOne(d => d.Employee).WithMany(p => p.WorkingSessions)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_working_session_employee");
        }
    }
}
