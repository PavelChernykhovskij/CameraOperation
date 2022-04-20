namespace CamerOperationClassLibrary.Models
{
    public class RuleOfSearchBySpeed : RuleOfSearch
    {
        public int Id { get; set; }

        public int Speed { get; set; }

        public int UserKey { get; set; }
        public List<TriggeringBySpeed> TriggeringsBySpeed { get; set; }

    }
}
