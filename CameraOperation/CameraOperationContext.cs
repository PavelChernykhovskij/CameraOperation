using Microsoft.EntityFrameworkCore;

namespace CameraOperation.Models
{


    public class CameraOperationContext : DbContext
    {
        public CameraOperationContext(DbContextOptions<CameraOperationContext> options) : base(options)
        {

        }

    }
}
