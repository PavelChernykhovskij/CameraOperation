using CamerOperationClassLibrary.Models;

namespace CamerOperationClassLibrary.Services
{
    public interface IViolationDetector
    {
        void ViolationDetect(Fixation fixation);
    }
}
