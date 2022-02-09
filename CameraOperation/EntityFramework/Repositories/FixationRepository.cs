using CameraOperation.Models; 

namespace CameraOperation.EntityFramework.Repositories
{
    public class FixationRepository : IFixationRepository<Fixation>
    {
        private readonly ICameraOperationContextFactory _factory;
        public FixationRepository(ICameraOperationContextFactory factory)
        {
            _factory = factory;    
        }

        public bool Create(Fixation data)
        {
            using var context = _factory.Create();
            {
                context.Fixations.Add(data);
                context.SaveChanges();
            }      
            return true;       
        }

        public bool Delete(Fixation data)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fixation> Read()
        {
            using var context = _factory.Create();
            return context.Fixations.ToList();
        }

        public bool Update(Fixation data)
        {
            throw new NotImplementedException();
        }
    }
}
