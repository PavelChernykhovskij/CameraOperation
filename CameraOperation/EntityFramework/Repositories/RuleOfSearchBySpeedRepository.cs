using CamerOperationClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace CamerOperationClassLibrary.EntityFramework.Repositories
{
    public class RuleOfSearchBySpeedRepository : IRepository<RuleOfSearchBySpeed>
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

        public IEnumerable<RuleOfSearchBySpeed> Read()
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

    }
}
