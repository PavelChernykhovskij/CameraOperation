using CameraOperation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CameraOperation.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasMany(u => u.RulesOfSearchByNumber)
                   .WithOne(r => r.User)
                   .HasForeignKey(t => t.UserKey);
            builder.HasMany(u => u.RulesOfSearchBySpeed)
                   .WithOne(r => r.User)
                   .HasForeignKey(t => t.UserKey);

            builder.Property(u => u.Login).IsRequired().HasMaxLength(20);
            builder.Property(u => u.Name).IsRequired().HasMaxLength(40);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(20);
        }
    }
}
