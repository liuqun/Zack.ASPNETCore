using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Data;

public class Role : IdentityRole<long>
{
    public DateTime DateCreated { get; set; }
    public bool SoftDeleted { get; set; }
}

public class RoleEntityConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("sys_role");

        builder.Property(role => role.DateCreated).HasColumnType("datetime(0)").IsRequired();

        builder.Property(role => role.SoftDeleted).HasColumnType("tinyint").IsRequired();

        builder.Property(role => role.Name).HasMaxLength(20).IsRequired();

        builder.Property(role => role.NormalizedName).HasMaxLength(20).IsRequired();

        builder.Property(role => role.ConcurrencyStamp).IsConcurrencyToken().HasMaxLength(36).IsUnicode(false).IsRequired().HasDefaultValue("");
    }
}