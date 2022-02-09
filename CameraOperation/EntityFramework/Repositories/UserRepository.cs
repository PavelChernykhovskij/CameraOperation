using CameraOperation.Models;

namespace CameraOperation.EntityFramework.Repositories
{
    public class UserRepository : IUserRepository<User>
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

        public bool Delete(User data)
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
            throw new NotImplementedException();
        }
    }
}
