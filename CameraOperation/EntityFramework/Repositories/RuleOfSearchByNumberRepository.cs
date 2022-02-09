using CameraOperation.Models;
using Microsoft.EntityFrameworkCore;

namespace CameraOperation.EntityFramework.Repositories
{
    public class RuleOfSearchByNumberRepository : IRuleOfSearchByNumberRepository<RuleOfSearchByNumber>
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

        public bool Delete(RuleOfSearchByNumber data)
        {
            using var context = _factory.Create();
            RuleOfSearchByNumber ruleOfSearchByNumber = context.RulesOfSearchByNumber.Find(data);
            context.RulesOfSearchByNumber.Remove(ruleOfSearchByNumber);
            context.SaveChanges();
            return true;
        }

        public RuleOfSearchByNumber ReadOne()
        {
            using var context = _factory.Create();
            return context.RulesOfSearchByNumber.FirstOrDefault();
        }

        public IEnumerable<RuleOfSearchByNumber> ReadAll()
        {
            using var context = _factory.Create();
            return context.RulesOfSearchByNumber.ToList();
        }

        public bool Update(RuleOfSearchByNumber data)
        {
            using var context = _factory.Create();
            context.Entry(data).State = EntityState.Modified;
            return true;
        }
    }
}
