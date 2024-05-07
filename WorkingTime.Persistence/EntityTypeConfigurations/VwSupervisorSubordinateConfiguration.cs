using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkingTime.Domain.Models;

namespace WorkingTime.Persistence.EntityTypeConfigurations
{
    public class VwSupervisorSubordinateConfiguration : IEntityTypeConfiguration<VwSupervisorSubordinate>
    {
        public void Configure(EntityTypeBuilder<VwSupervisorSubordinate> builder)
        {
            builder
                .HasNoKey()
                .ToView("vw_supervisor_subordinate");

            builder.Property(e => e.SubordinateFirstName)
                .HasMaxLength(45)
                .HasColumnName("subordinate_first_name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            builder.Property(e => e.SubordinateId).HasColumnName("subordinate_id");
            builder.Property(e => e.SupervisorId).HasColumnName("supervisor_id");
            builder.Property(e => e.SubordinatePatronymic)
                .HasMaxLength(45)
                .HasColumnName("subordinate_patronymic")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            builder.Property(e => e.SubordinateSurname)
                .HasMaxLength(45)
                .HasColumnName("subordinate_surname")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            builder.Property(e => e.SupervisoFirstName)
                .HasMaxLength(45)
                .HasColumnName("superviso_first_name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            builder.Property(e => e.SupervisorPatronymic)
                .HasMaxLength(45)
                .HasColumnName("supervisor_patronymic")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            builder.Property(e => e.SupervisorSurname)
                .HasMaxLength(45)
                .HasColumnName("supervisor_surname")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        }
    }
}
