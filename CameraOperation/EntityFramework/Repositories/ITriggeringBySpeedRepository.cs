namespace CameraOperation.EntityFramework.Repositories
{
    public interface ITriggeringBySpeedRepository<T>
    {
        bool Create(T data);
        IEnumerable<T> Read();
        bool Update(T data);
        bool Delete(T data);
    }
}
