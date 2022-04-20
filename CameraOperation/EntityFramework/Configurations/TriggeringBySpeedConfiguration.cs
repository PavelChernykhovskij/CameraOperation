using CamerOperationClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CamerOperationClassLibrary.Configurations
{
    public class TriggeringBySpeedConfiguration : IEntityTypeConfiguration<TriggeringBySpeed>
    {
        public void Configure(EntityTypeBuilder<TriggeringBySpeed> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(ts => ts.CarSpeed).IsRequired();
            builder.Property(ts => ts.FixationDate).IsRequired().HasMaxLength(28).HasColumnType("datetime2(2)");
        }
    }
}

