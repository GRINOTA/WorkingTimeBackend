using Microsoft.EntityFrameworkCore;
using WorkingTime.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WorkingTime.Persistence.EntityTypeConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder) 
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");
            builder.ToTable("role");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.RoleName)
                .HasMaxLength(20)
                .HasColumnName("role_name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        }
    }
}
