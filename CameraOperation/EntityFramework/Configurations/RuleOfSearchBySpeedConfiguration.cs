using CameraOperation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CameraOperation.Configurations
{
    public class RuleOfSearchBySpeedConfiguration : IEntityTypeConfiguration<RuleOfSearchBySpeed>
    {
        public void Configure(EntityTypeBuilder<RuleOfSearchBySpeed> builder)
        {

            builder.HasMany(r => r.TriggeringsBySpeed)
                   .WithOne(t => t.RuleOfSearchBySpeed)
                   .HasForeignKey(t => t.RuleOfSearchBySpeedId);

            builder.HasKey(rs => rs.Id);
            builder.Property(rs => rs.Speed).IsRequired();
            builder.Property(rs => rs.DateOfCreate).IsRequired().HasMaxLength(28).HasColumnType("datetime2(2)");
        }
    }
}
