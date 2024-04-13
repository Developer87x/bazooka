using Bazooka.Identity.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazooka.Identity.Api.Infrastructure.EntityConfigurations;

public class UserRoleTypeConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRoles",IdentityContext.ContextSchema);
        builder.HasKey(s=> new {s.UserId,s.RoleId});
        builder.HasOne(s=>s.User).WithMany(s=>s.UserRoles).HasForeignKey(s=>s.UserId);
        builder.HasOne(s=>s.Role).WithMany(s=>s.UserRoles).HasForeignKey(s=>s.RoleId);
        
    }
}