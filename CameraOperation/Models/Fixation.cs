using CamerOperationClassLibrary.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CamerOperationClassLibrary.Models
{
    public class Fixation
    {
        public int Id { get; set; }

        public DateTime FixationDate { get; set; }
        public int CarSpeed { get; set; }
        public string CarNumber { get; set; }
    }
}
