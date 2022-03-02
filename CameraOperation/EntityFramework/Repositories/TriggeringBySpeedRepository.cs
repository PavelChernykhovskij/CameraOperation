using CameraOperation.Models;
namespace CameraOperation.EntityFramework.Repositories
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
            throw new NotImplementedException();
        }

        public bool Delete(TriggeringBySpeed data)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TriggeringBySpeed> Read()
        {
            using var context = _factory.Create();
            return context.TriggeringBySpeeds.ToList();
        }

        public bool Update(TriggeringBySpeed data)
        {
            throw new NotImplementedException();
        }
    }
}
