using CameraOperation.Models;

namespace CameraOperation.Services
{
    public interface IConcreteViolationDetector
    {
        void ViolationDetect(Fixation fixation);
    }
}
