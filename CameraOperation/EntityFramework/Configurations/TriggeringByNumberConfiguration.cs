using CamerOperationClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CamerOperationClassLibrary.Configurations
{
    public class TriggeringByNumberConfiguration : IEntityTypeConfiguration<TriggeringByNumber>
    {
        public void Configure(EntityTypeBuilder<TriggeringByNumber> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(tn => tn.CarNumber).IsRequired().HasMaxLength(10);
            builder.Property(tn => tn.FixationDate).IsRequired().HasMaxLength(28).HasColumnType("datetime2(2)");

        }
    }
}
