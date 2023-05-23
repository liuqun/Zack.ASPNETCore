using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class User : IdentityUser<long>
{
    public DateTime DateCreated { get; set; }
    public string? NickName { get; set; }
}

public class UserEntityConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("sys_user");

        builder.Property(user => user.NickName).HasMaxLength(20).IsRequired().HasDefaultValue("");

        builder.Property(user => user.DateCreated).HasColumnType("datetime(0)");

        builder.Property(user => user.UserName).HasMaxLength(20).IsRequired();

        builder.Property(user => user.NormalizedUserName).HasMaxLength(20).IsRequired();

        #region 邮件Email
        builder.Property(user => user.Email).HasMaxLength(30).IsRequired().HasDefaultValue("");
        builder.Property(user => user.NormalizedEmail).HasMaxLength(30).IsRequired().HasDefaultValue("");
        builder.Property(user => user.EmailConfirmed).HasColumnType("tinyint");
        #endregion

        //builder.Property(user => user.PasswordHash).HasColumnType("char(64)");

        builder.Property(user => user.SecurityStamp).HasMaxLength(36).IsUnicode(false).IsRequired().HasDefaultValue("");

        builder.Property(user => user.ConcurrencyStamp).IsConcurrencyToken().HasMaxLength(36).IsUnicode(false).IsRequired().HasDefaultValue("");

        #region 绑定的电话号码
        builder.Property(user => user.PhoneNumber).HasMaxLength(16).IsRequired().HasDefaultValue("");
        builder.Property(user => user.PhoneNumberConfirmed).HasColumnType("tinyint");
        #endregion

        builder.Property(user => user.TwoFactorEnabled).HasColumnType("tinyint");

        builder.Property(user => user.LockoutEnd).HasColumnType("datetime(0)");
        builder.Property(user => user.LockoutEnabled).HasColumnType("tinyint");

        builder.Property(user => user.AccessFailedCount).IsRequired().HasDefaultValue(0);
    }
}
