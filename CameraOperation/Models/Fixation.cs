using CameraOperation.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CameraOperation.Models
{
    public class Fixation
    {
        public int Id { get; set; }

        public DateTime FixationDate { get; set; }
        public int CarSpeed { get; set; }
        public string CarNumber { get; set; }

        public TriggeringByNumber TriggeringByNumber { get; set; }
        public TriggeringBySpeed TriggeringBySpeed { get; set; }
    }
}
