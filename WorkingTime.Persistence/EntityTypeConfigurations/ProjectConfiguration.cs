using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkingTime.Domain.Models;

namespace WorkingTime.Persistence.EntityTypeConfigurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("project");

            builder.HasIndex(e => e.SupervisorEmployeeId, "fk_project_supervisor_idx");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.ProjectDescription)
                .HasColumnType("text")
                .HasColumnName("project_description");
            builder.Property(e => e.ProjectName)
                .HasMaxLength(50)
                .HasColumnName("project_name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            builder.Property(e => e.SupervisorEmployeeId).HasColumnName("supervisor_employee_id");

            builder.HasOne(d => d.SupervisorEmployee).WithMany(p => p.Projects)
                .HasForeignKey(d => d.SupervisorEmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_project_supervisor");
        }
    }
}
