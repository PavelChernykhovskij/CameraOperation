using CameraOperation.Models;
namespace CameraOperation.EntityFramework.Repositories
{
    public class TriggeringByNumberRepository : ITriggeringByNumberRepository<TriggeringByNumber>
    {

        private readonly ICameraOperationContextFactory _factory;
        public TriggeringByNumberRepository(ICameraOperationContextFactory factory)
        {
            _factory = factory;
        }
        public bool Create(TriggeringByNumber data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TriggeringByNumber data)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TriggeringByNumber> Read()
        {
            using var context = _factory.Create();
            return context.TriggeringByNumbers.ToList();
        }

        public bool Update(TriggeringByNumber data)
        {
            throw new NotImplementedException();
        }
    }
}
