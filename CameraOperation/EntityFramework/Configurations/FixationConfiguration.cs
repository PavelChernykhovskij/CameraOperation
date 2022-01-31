using CameraOperation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CameraOperation.Configurations
{
    public class FixationConfiguration : IEntityTypeConfiguration<Fixation>
    {
        public void Configure(EntityTypeBuilder<Fixation> builder)
        {
            builder.HasOne(f => f.TriggeringByNumber)
                   .WithOne(t => t.Fixation)
                   .HasForeignKey<TriggeringByNumber>(t => t.FixationKey);

            builder.HasOne(f => f.TriggeringBySpeed)
                   .WithOne(t => t.Fixation)
                   .HasForeignKey<TriggeringBySpeed>(t => t.FixationKey);

            builder.Property(f => f.CarNumber).IsRequired().HasMaxLength(10);
            builder.Property(f => f.CarSpeed).IsRequired();
            builder.Property(f => f.FixationDate).IsRequired().HasMaxLength(28).HasColumnType("datetime2(2)");
        }
    }
}
