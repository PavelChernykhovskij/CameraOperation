namespace CameraOperation.Models
{
    public class Fixation
    {
        public int Id { get; set; }

        public DateTime FixationDate { get; set; }
        public int CarSpeed { get; set; }
        public string CarNumber { get; set; }

        public int UserKey { get; set; }
        public User User { get; set; }
    }
}
