using CamerOperationClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace CamerOperationClassLibrary.EntityFramework.Repositories
{
    public class RuleOfSearchByNumberRepository : IRepository<RuleOfSearchByNumber>
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

        public IEnumerable<RuleOfSearchByNumber> Read()
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

      
    }
}
