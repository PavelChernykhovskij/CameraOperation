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
            return context.RulesOfSearchBySpeed.FirstOrDefault();
        }

        public IEnumerable<RuleOfSearchBySpeed> ReadAll()
        {
            using var context = _factory.Create();
            return context.RulesOfSearchBySpeed.ToList();
        }

        public bool Update(RuleOfSearchBySpeed data)
        {
            using var context = _factory.Create();
            context.Entry(data).State = EntityState.Modified;
            return true;
        }
    }
}
