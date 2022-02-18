using Microsoft.EntityFrameworkCore;
using CameraOperation.Models;
using CameraOperation.Configurations;

namespace CameraOperation
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
            : base(options)
        {
            if (Database.EnsureCreated())
            {
                using (CameraOperationContext context = new CameraOperationContext(options))
                {
                    FillDatabase(context);
                }
            }



        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FixationConfiguration());
            modelBuilder.ApplyConfiguration(new RuleOfSearchByNumberConfiguration());
            modelBuilder.ApplyConfiguration(new RuleOfSearchBySpeedConfiguration());
            modelBuilder.ApplyConfiguration(new TriggeringByNumberConfiguration());
            modelBuilder.ApplyConfiguration(new TriggeringBySpeedConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        private static void FillDatabase(CameraOperationContext db)
        {

            User user1 = new User { Name = "LeonardoDicaprio", Login = "Boy", Password = "123" };
            User user2 = new User { Name = "DmitriyPuchkov", Login = "Old", Password = "123" };
            

            RuleOfSearchByNumber ruleOfSearchByNumber1 = new RuleOfSearchByNumber { User = user1, DateOfCreate = DateTime.Now, Number = "231" };
            RuleOfSearchByNumber ruleOfSearchByNumber2 = new RuleOfSearchByNumber { User = user2, DateOfCreate = DateTime.Now, Number = "2222" };

            RuleOfSearchBySpeed ruleOfSearchBySpeed1 = new RuleOfSearchBySpeed { User = user1, DateOfCreate = DateTime.Now, Speed = 123 };
            RuleOfSearchBySpeed ruleOfSearchBySpeed2 = new RuleOfSearchBySpeed { User = user2, DateOfCreate = DateTime.Now, Speed = 90 };

            Fixation fixation1 = new Fixation { FixationDate = DateTime.Now, CarNumber = "231", CarSpeed = 123 };
            Fixation fixation2 = new Fixation { FixationDate = DateTime.Now, CarNumber = "2222", CarSpeed = 133 };
            Fixation fixation3 = new Fixation { FixationDate = DateTime.Now, CarNumber = "132", CarSpeed = 104 };
            Fixation fixation4 = new Fixation { FixationDate = DateTime.Now, CarNumber = "43", CarSpeed = 100 };

            TriggeringByNumber triggeringByNumber1 = new TriggeringByNumber { Fixation = fixation1, CarNumber = fixation1.CarNumber, FixationDate = fixation1.FixationDate, RuleOfSearchByNumber = ruleOfSearchByNumber1 };
            TriggeringByNumber triggeringByNumber2 = new TriggeringByNumber { Fixation = fixation2, CarNumber = fixation2.CarNumber, FixationDate = fixation2.FixationDate, RuleOfSearchByNumber = ruleOfSearchByNumber2 };

            TriggeringBySpeed triggeringBySpeed1 = new TriggeringBySpeed { Fixation = fixation3, CarSpeed = fixation3.CarSpeed, FixationDate = fixation3.FixationDate, RuleOfSearchBySpeed = ruleOfSearchBySpeed1 };
            TriggeringBySpeed triggeringBySpeed2 = new TriggeringBySpeed { Fixation = fixation4, CarSpeed = fixation4.CarSpeed, FixationDate = fixation4.FixationDate, RuleOfSearchBySpeed = ruleOfSearchBySpeed1 };

            db.Users.Add(user1);
            db.Users.Add(user2);
            db.RulesOfSearchByNumber.AddRange(ruleOfSearchByNumber1, ruleOfSearchByNumber2);
            db.RulesOfSearchBySpeed.AddRange(ruleOfSearchBySpeed1, ruleOfSearchBySpeed2);
            db.Fixations.AddRange(fixation1, fixation2, fixation3, fixation4);
            db.TriggeringByNumbers.AddRange(triggeringByNumber1, triggeringByNumber2);
            db.TriggeringBySpeeds.AddRange(triggeringBySpeed1, triggeringBySpeed2);
            db.SaveChanges();

        }

    }
}


