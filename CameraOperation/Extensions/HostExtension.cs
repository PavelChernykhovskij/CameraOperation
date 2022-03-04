using CameraOperation.Models;
namespace CameraOperation
{
    public static class HostExtension
    {
        public static IHost EnsureDatabaseCreated(this IHost host)
        {

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var context = services.GetService<CameraOperationContext>();
                if (context.Database.EnsureCreated())
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

                    context.Users.Add(user1);
                    context.Users.Add(user2);
                    context.RulesOfSearchByNumber.AddRange(ruleOfSearchByNumber1, ruleOfSearchByNumber2);
                    context.RulesOfSearchBySpeed.AddRange(ruleOfSearchBySpeed1, ruleOfSearchBySpeed2);
                    context.Fixations.AddRange(fixation1, fixation2, fixation3, fixation4);
                    context.TriggeringByNumbers.AddRange(triggeringByNumber1, triggeringByNumber2);
                    context.TriggeringBySpeeds.AddRange(triggeringBySpeed1, triggeringBySpeed2);
                    context.SaveChanges();
                }
            }
            return host;

        }
    }
}
