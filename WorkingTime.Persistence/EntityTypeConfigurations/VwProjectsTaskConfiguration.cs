using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkingTime.Domain.Models;

namespace WorkingTime.Persistence.EntityTypeConfigurations
{
    public class VwProjectsTaskConfiguration : IEntityTypeConfiguration<VwProjectsTask>
    {
        public void Configure(EntityTypeBuilder<VwProjectsTask> builder)
        {
            builder
                .HasNoKey()
                .ToView("vw_projects_tasks");

            builder.Property(e => e.CreatorFirstName)
                .HasMaxLength(45)
                .HasColumnName("creator_first_name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            builder.Property(e => e.CreatorId).HasColumnName("creator_id");
            builder.Property(e => e.CreatorPatronymic)
                .HasMaxLength(45)
                .HasColumnName("creator_patronymic")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            builder.Property(e => e.CreatorSurname)
                .HasMaxLength(45)
                .HasColumnName("creator_surname")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            builder.Property(e => e.Deadline)
                .HasColumnType("datetime")
                .HasColumnName("deadline");
            builder.Property(e => e.EndTask)
                .HasColumnType("datetime")
                .HasColumnName("end_task");
            builder.Property(e => e.ExecutorFirstName)
                .HasMaxLength(45)
                .HasColumnName("executor_first_name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            builder.Property(e => e.ExecutorPatronymic)
                .HasMaxLength(45)
                .HasColumnName("executor_patronymic")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            builder.Property(e => e.ExecutorSurname)
                .HasMaxLength(45)
                .HasColumnName("executor_surname")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.ProjectName)
                .HasMaxLength(50)
                .HasColumnName("project_name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            builder.Property(e => e.StartTask)
                .HasColumnType("datetime")
                .HasColumnName("start_task");
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
        }
    }
}
