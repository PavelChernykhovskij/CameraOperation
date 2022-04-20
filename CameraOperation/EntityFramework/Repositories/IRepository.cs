using CamerOperationClassLibrary.Models;

namespace CamerOperationClassLibrary.EntityFramework.Repositories
{
    public interface IRepository<T>
    {
        bool Create(T data);
        IEnumerable<T> Read();
        bool Update(T data);
        bool Delete(T data);
    }
}
