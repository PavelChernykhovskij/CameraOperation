namespace CameraOperation.EntityFramework.Repositories
{
    public interface ITriggeringByNumberRepository<T>
    {
        bool Create(T data);
        IEnumerable<T> Read();
        bool Update(T data);
        bool Delete(T data);
    }
}
