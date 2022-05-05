namespace CamerOperationClassLibrary.Models
{
    public class TriggeringByNumber
    {
        public int Id { get; set; }

        public int FixationId { get; set; }
        public int RuleOfSearchByNumberId { get; set; }

        public DateTime FixationDate { get; set; }
        public string CarNumber { get; set; }

        public Fixation Fixation { get; set; }
        public RuleOfSearchByNumber RuleOfSearchByNumber { get; set; }

    }
}
