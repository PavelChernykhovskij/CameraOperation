using CamerOperationClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CamerOperationClassLibrary.Configurations
{
    public class FixationConfiguration : IEntityTypeConfiguration<Fixation>
    {
        public void Configure(EntityTypeBuilder<Fixation> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.CarNumber).IsRequired().HasMaxLength(10);
            builder.Property(f => f.CarSpeed).IsRequired();
            builder.Property(f => f.FixationDate).IsRequired().HasMaxLength(28).HasColumnType("datetime2(2)");
        }
    }
}
