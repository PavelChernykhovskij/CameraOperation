namespace CameraOperation.EntityFramework.Repositories
{
    public interface IRuleOfSearchByNumberRepository<T>
    {
        bool Create(T data);
        T ReadOne();
        IEnumerable<T> ReadAll();
        bool Update(T data);
        bool Delete(T data);
    }
}
