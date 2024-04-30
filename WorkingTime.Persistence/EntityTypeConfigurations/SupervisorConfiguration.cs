using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkingTime.Domain.Models;

namespace WorkingTime.Persistence.EntityTypeConfigurations
{
    public class SupervisorConfiguration : IEntityTypeConfiguration<Supervisor>
    {
        public void Configure(EntityTypeBuilder<Supervisor> builder)
        {
            builder.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            builder.ToTable("supervisor");

            builder.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("employee_id");

            builder.HasOne(d => d.Employee).WithOne(p => p.Supervisor)
                .HasForeignKey<Supervisor>(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_supervisor_employee");
        }
    }
}
