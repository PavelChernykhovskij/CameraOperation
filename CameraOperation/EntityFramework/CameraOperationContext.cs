using CamerOperationClassLibrary.Configurations;
using CamerOperationClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace CamerOperationClassLibrary
{
    public class CameraOperationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Fixation> Fixations => Set<Fixation>();
        public DbSet<RuleOfSearchByNumber> RulesOfSearchByNumber => Set<RuleOfSearchByNumber>();
        public DbSet<RuleOfSearchBySpeed> RulesOfSearchBySpeed => Set<RuleOfSearchBySpeed>();
        public DbSet<TriggeringByNumber> TriggeringByNumbers => Set<TriggeringByNumber>();
        public DbSet<TriggeringBySpeed> TriggeringBySpeeds => Set<TriggeringBySpeed>();

        public CameraOperationContext(DbContextOptions<CameraOperationContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FixationConfiguration());
            modelBuilder.ApplyConfiguration(new RuleOfSearchByNumberConfiguration());
            modelBuilder.ApplyConfiguration(new RuleOfSearchBySpeedConfiguration());
            modelBuilder.ApplyConfiguration(new TriggeringByNumberConfiguration());
            modelBuilder.ApplyConfiguration(new TriggeringBySpeedConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
