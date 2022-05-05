namespace CamerOperationClassLibrary.Models
{
    public class TriggeringBySpeed
    {
        public int Id { get; set; }

        public int FixationId { get; set; }
        public int RuleOfSearchBySpeedId { get; set; }

        public DateTime FixationDate { get; set; }
        public int CarSpeed { get; set; }

        public Fixation Fixation { get; set; }
        public RuleOfSearchBySpeed RuleOfSearchBySpeed { get; set; }
    }
}
