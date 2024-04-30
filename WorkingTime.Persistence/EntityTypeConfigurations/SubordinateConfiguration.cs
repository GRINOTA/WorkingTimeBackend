using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkingTime.Domain.Models;

namespace WorkingTime.Persistence.EntityTypeConfigurations
{
    public class SubordinateConfiguration : IEntityTypeConfiguration<Subordinate>
    {
        public void Configure(EntityTypeBuilder<Subordinate> builder)
        {
            builder.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            builder.ToTable("subordinate");

            builder.HasIndex(e => e.SupervisorEmployeeId, "fk_subordinate_supervisor_idx");

            builder.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("employee_id");
            builder.Property(e => e.SupervisorEmployeeId).HasColumnName("supervisor_employee_id");

            builder.HasOne(d => d.Employee).WithOne(p => p.Subordinate)
                .HasForeignKey<Subordinate>(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_subordinate_employee");

            builder.HasOne(d => d.SupervisorEmployee).WithMany(p => p.Subordinates)
                .HasForeignKey(d => d.SupervisorEmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_subordinate_supervisor");
        }
    }
}
