using CamerOperationClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
namespace CamerOperationClassLibrary.EntityFramework.Repositories
{
    public class TriggeringBySpeedRepository : IRepository<TriggeringBySpeed>
    {

        private readonly ICameraOperationContextFactory _factory;
        public TriggeringBySpeedRepository(ICameraOperationContextFactory factory)
        {
            _factory = factory;
        }
        public bool Create(TriggeringBySpeed data)
        {
            using var context = _factory.Create();
            {
                context.TriggeringBySpeeds.Add(data);
                context.Entry(data.Fixation).State = EntityState.Modified;
                context.Entry(data.RuleOfSearchBySpeed).State = EntityState.Modified;
                context.Entry(data.RuleOfSearchBySpeed.User).State = EntityState.Modified;
                context.SaveChanges();
            }
            return true;
        }
        public bool Delete(TriggeringBySpeed data)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<TriggeringBySpeed> Read()
        {
            using var context = _factory.Create();
            var triggers = context.TriggeringBySpeeds.Include(r => r.RuleOfSearchBySpeed).ToList();
            return triggers;
        }
        public bool Update(TriggeringBySpeed data)
        {
            throw new NotImplementedException();
        }
    }
}
