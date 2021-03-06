using CamerOperationClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace CamerOperationClassLibrary.EntityFramework.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly ICameraOperationContextFactory _factory;
        public UserRepository(ICameraOperationContextFactory factory)
        {
            _factory = factory;
        }
        public bool Create(User data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Read()
        {
            using var context = _factory.Create();
            return context.Users.ToList();
        }

        public bool Update(User data)
        {
            using var context = _factory.Create();
            context.Entry(data).State = EntityState.Modified;
            return true;
        }
    }
}
