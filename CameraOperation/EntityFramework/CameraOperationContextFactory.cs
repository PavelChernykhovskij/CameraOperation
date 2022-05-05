using Microsoft.EntityFrameworkCore;
namespace CamerOperationClassLibrary.EntityFramework
{
    public class CameraOperationContextFactory : ICameraOperationContextFactory 
    {
        private readonly DbContextOptions<CameraOperationContext> _options;
        public CameraOperationContextFactory(DbContextOptions<CameraOperationContext> options)
        {
            _options = options;
        }

        public CameraOperationContext Create()
        {
            return new CameraOperationContext(_options);
        }
    }
}
