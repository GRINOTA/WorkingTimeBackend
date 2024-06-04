using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkingTime.Domain.Models;

namespace WorkingTime.Persistence.EntityTypeConfigurations
{
    public class VwWorkingSessionEmployeeConfiguration : IEntityTypeConfiguration<VwWorkingSessionEmployee>
    {
        public void Configure(EntityTypeBuilder<VwWorkingSessionEmployee> builder)
        {
            builder
                .HasNoKey()
                .ToView("vw_working_session_employee");

            builder.Property(e => e.CompletedTaskNumber)
                .HasDefaultValueSql("'0'")
                .HasColumnName("completed_task_number");
            builder.Property(e => e.EndDay)
                .HasColumnType("datetime")
                .HasColumnName("end_day");
            builder.Property(e => e.FirstName)
                .HasMaxLength(45)
                .HasColumnName("first_name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Patronymic)
                .HasMaxLength(45)
                .HasColumnName("patronymic")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            builder.Property(e => e.PerformanceEvaluation)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("performance_evaluation");
            builder.Property(e => e.StartDay)
                .HasColumnType("datetime")
                .HasColumnName("start_day");
            builder.Property(e => e.Surname)
                .HasMaxLength(45)
                .HasColumnName("surname")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            builder.Property(e => e.TotalWorkingTime).HasColumnName("total_working_time");
        }
    }
}
