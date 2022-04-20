using CamerOperationClassLibrary.Models;

namespace CamerOperationClassLibrary.EntityFramework.Repositories
{
    public interface IRuleOfSearchRepository<T>
    {
        bool Create(T data);
        T ReadOne();
        IEnumerable<T> ReadAll();
        bool Update(T data);
        bool Delete(int id);
    }
}