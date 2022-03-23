using CameraOperation.Models;
using Microsoft.EntityFrameworkCore;

namespace CameraOperation.EntityFramework.Repositories
{
    public class RuleOfSearchBySpeedRepository : IRuleOfSearchRepository<RuleOfSearchBySpeed>
    {
        private readonly ICameraOperationContextFactory _factory;
        public RuleOfSearchBySpeedRepository(ICameraOperationContextFactory factory)
        {
            _factory = factory;
            using var context = _factory.Create();
        }

        public bool Create(RuleOfSearchBySpeed data)
        {
            using var context = _factory.Create();
            context.RulesOfSearchBySpeed.Add(data);
            context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            using var context = _factory.Create();
            RuleOfSearchBySpeed ruleOfSearchBySpeed = context.RulesOfSearchBySpeed.Find(id);
            context.RulesOfSearchBySpeed.Remove(ruleOfSearchBySpeed);
            context.SaveChanges();
            return true;
        }

        public RuleOfSearchBySpeed ReadOne()
        {
            using var context = _factory.Create();
            var rules = context.RulesOfSearchBySpeed.Include(u => u.User).ToList();
            return rules.FirstOrDefault();
        }

        public IEnumerable<RuleOfSearchBySpeed> ReadAll()
        {
            using var context = _factory.Create();
            var rules = context.RulesOfSearchBySpeed.Include(u => u.User).ToList();
            return rules;
        }

        public bool Update(RuleOfSearchBySpeed data)
        {
            using var context = _factory.Create();
            context.Entry(data).State = EntityState.Modified;
            return true;
        }

        public void Detect(Fixation fixation)
        {
            using var context = _factory.Create();
            IEnumerable<RuleOfSearchBySpeed> violations = context.RulesOfSearchBySpeed.ToList();
            if (fixation != null)
            {
                foreach (RuleOfSearchBySpeed violation in violations)
                {
                    if (fixation.CarSpeed >= violation.Speed)
                    {
                        context.Fixations.Add(fixation);
                        context.SaveChanges();
                        Fixation fixation1 = context.Fixations.FirstOrDefault(f => f.Id == fixation.Id);
                        RuleOfSearchBySpeed ruleOfSearchBySpeed = context.RulesOfSearchBySpeed.FirstOrDefault(rs => rs.Id == violation.Id);
                        TriggeringBySpeed triggeringBySpeed = new TriggeringBySpeed() { CarSpeed = fixation.CarSpeed, FixationDate = fixation.FixationDate, Fixation = fixation1, RuleOfSearchBySpeed = ruleOfSearchBySpeed };
                        context.TriggeringBySpeeds.Add(triggeringBySpeed);
                    }
                }
            }
            context.SaveChanges();
        }
    }
}
