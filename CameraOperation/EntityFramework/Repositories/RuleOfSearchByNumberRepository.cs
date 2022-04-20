using CamerOperationClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace CamerOperationClassLibrary.EntityFramework.Repositories
{
    public class RuleOfSearchByNumberRepository : IRuleOfSearchRepository<RuleOfSearchByNumber>
    {
        private readonly ICameraOperationContextFactory _factory;
        public RuleOfSearchByNumberRepository(ICameraOperationContextFactory factory)
        {
            _factory = factory;
            using var context = _factory.Create();
        }
        public bool Create(RuleOfSearchByNumber data)
        {
            using var context = _factory.Create();         
            context.RulesOfSearchByNumber.Add(data);
            context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            using var context = _factory.Create();
            RuleOfSearchByNumber ruleOfSearchByNumber = context.RulesOfSearchByNumber.Find(id);
            context.RulesOfSearchByNumber.Remove(ruleOfSearchByNumber);
            context.SaveChanges();
            return true;
        }

        public RuleOfSearchByNumber ReadOne()
        {
            using var context = _factory.Create();
            var rules = context.RulesOfSearchByNumber.Include(u => u.User).ToList();
            return rules.FirstOrDefault();
        }

        public IEnumerable<RuleOfSearchByNumber> ReadAll()
        {
            using var context = _factory.Create();
            var rules = context.RulesOfSearchByNumber.Include(u => u.User).ToList();
            return rules;
        }

        public bool Update(RuleOfSearchByNumber data)
        {
            using var context = _factory.Create();
            context.Entry(data).State = EntityState.Modified;
            return true;
        }

        //public void Detect(Fixation fixation)
        //{
        //    using var context = _factory.Create();
        //    IEnumerable<RuleOfSearchByNumber> violations = context.RulesOfSearchByNumber.ToList();
        //    if (fixation != null)
        //    {
        //        foreach (RuleOfSearchByNumber violation in violations)
        //        {
        //            if (violation.Number == fixation.CarNumber)
        //            {
        //                context.Fixations.Add(fixation);
        //                context.SaveChanges();
        //                Fixation fixation1 = context.Fixations.FirstOrDefault(f => f.Id == fixation.Id);
        //                RuleOfSearchByNumber ruleOfSearchByNumber = context.RulesOfSearchByNumber.FirstOrDefault(rn => rn.Id == violation.Id);
        //                TriggeringByNumber triggeringByNumber = new TriggeringByNumber() { CarNumber = fixation.CarNumber, FixationDate = fixation.FixationDate, Fixation = fixation1, RuleOfSearchByNumber = ruleOfSearchByNumber };
        //                context.TriggeringByNumbers.Add(triggeringByNumber);
        //            }
        //        }
        //    }
        //    context.SaveChanges();
        //}
    }
}
