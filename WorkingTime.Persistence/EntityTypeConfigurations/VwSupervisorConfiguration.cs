using Microsoft.EntityFrameworkCore;
using WorkingTime.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WorkingTime.Persistence.EntityTypeConfigurations
{
    public class VwSupervisorConfiguration : IEntityTypeConfiguration<VwSupervisor>
    {
        public void Configure(EntityTypeBuilder<VwSupervisor> builder)
        {
            builder
                .HasNoKey()
                .ToView("vw_supervisor");

            builder.Property(e => e.EmployeeId).HasColumnName("employee_id");
            builder.Property(e => e.FirstName)
                .HasMaxLength(45)
                .HasColumnName("first_name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Login)
                .HasMaxLength(45)
                .HasColumnName("login");
            builder.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            builder.Property(e => e.Patronymic)
                .HasMaxLength(45)
                .HasColumnName("patronymic")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            builder.Property(e => e.RoleId).HasColumnName("role_id");
            builder.Property(e => e.Surname)
                .HasMaxLength(45)
                .HasColumnName("surname")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        }
    }
}
