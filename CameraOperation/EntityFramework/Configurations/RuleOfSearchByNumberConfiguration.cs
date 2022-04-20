using CamerOperationClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CamerOperationClassLibrary.Configurations
{
    public class RuleOfSearchByNumberConfiguration : IEntityTypeConfiguration<RuleOfSearchByNumber>
    {
        public void Configure(EntityTypeBuilder<RuleOfSearchByNumber> builder)
        {
           
            builder.HasMany(r => r.TriggeringsByNumber)
                   .WithOne(t => t.RuleOfSearchByNumber)
                   .HasForeignKey(t => t.RuleOfSearchByNumberId);
            builder.HasKey(rn => rn.Id);
            builder.Property(rn => rn.Number).IsRequired().HasMaxLength(10);
            builder.Property(rn => rn.DateOfCreate).IsRequired().HasMaxLength(28).HasColumnType("datetime2(2)");
        }
    }
}
