using Microsoft.EntityFrameworkCore;
using CameraOperation.Models;

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
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        }

    }

}

