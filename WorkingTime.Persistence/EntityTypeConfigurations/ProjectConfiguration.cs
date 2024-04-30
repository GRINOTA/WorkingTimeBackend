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

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.ProjectDescription)
                .HasColumnType("text")
                .HasColumnName("project_description");
            builder.Property(e => e.ProjectName)
                .HasMaxLength(50)
                .HasColumnName("project_name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        }
    }
}
