using CamerOperationClassLibrary.Models;
using CamerOperationClassLibrary.Services;
using Microsoft.EntityFrameworkCore;

namespace CamerOperationClassLibrary.EntityFramework.Repositories
{
    public class FixationRepository : IRepository<Fixation>
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

        public bool Delete(int id)
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
            using var context = _factory.Create();
            context.Entry(data).State = EntityState.Modified;
            return true;
        }
    }
}
