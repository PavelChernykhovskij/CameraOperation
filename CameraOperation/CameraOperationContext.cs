using Microsoft.EntityFrameworkCore;
using CameraOperation.Models;
using CameraOperation.Configurations;

namespace CameraOperation
{

    public class CameraOperationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Fixation> Fixations { get; set; }
        public DbSet<RuleOfSearchByNumber> RulesOfSearchByNumber { get; set; }
        public DbSet<RuleOfSearchBySpeed> RulesOfSearchBySpeed { get; set; }
        public DbSet<TriggeringByNumber> TriggeringByNumbers { get; set; }
        public DbSet<TriggeringBySpeed> TriggeringBySpeeds { get; set; }

        public CameraOperationContext(DbContextOptions<CameraOperationContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<RuleOfSearch>();
            modelBuilder.ApplyConfiguration(new FixationConfiguration());
            modelBuilder.ApplyConfiguration(new RuleOfSearchByNumberConfiguration());
            modelBuilder.ApplyConfiguration(new RuleOfSearchBySpeedConfiguration());
            modelBuilder.ApplyConfiguration(new TriggeringByNumberConfiguration());
            modelBuilder.ApplyConfiguration(new TriggeringBySpeedConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

    }

}

