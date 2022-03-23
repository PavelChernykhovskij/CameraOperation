namespace CameraOperation.Models
{
    public class TriggeringBySpeed
    {
        public int Id { get; set; }
        public DateTime FixationDate { get; set; }
        public int CarSpeed { get; set; }

        public Fixation Fixation { get; set; }


        public int RuleOfSearchBySpeedId { get; set; }
        public RuleOfSearchBySpeed RuleOfSearchBySpeed { get; set; }
    }
}
