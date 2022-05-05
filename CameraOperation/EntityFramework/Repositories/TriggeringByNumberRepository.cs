using CamerOperationClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace CamerOperationClassLibrary.EntityFramework.Repositories
{
    public class TriggeringByNumberRepository : IRepository<TriggeringByNumber>
    {

        private readonly ICameraOperationContextFactory _factory;
        public TriggeringByNumberRepository(ICameraOperationContextFactory factory)
        {
            _factory = factory;
        }

        public bool Create(TriggeringByNumber data)
        {
            using var context = _factory.Create();
            context.TriggeringByNumbers.Add(data);
            context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TriggeringByNumber> Read()
        {
            using var context = _factory.Create();
            var triggers = context.TriggeringByNumbers.Include(r => r.RuleOfSearchByNumber).ToList();
            return triggers;
        }

        public bool Update(TriggeringByNumber data)
        {
            throw new NotImplementedException();
        }
    }
}
