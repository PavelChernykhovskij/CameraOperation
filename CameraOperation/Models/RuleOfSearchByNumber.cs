namespace CameraOperation.Models
{
    public class RuleOfSearchByNumber : RuleOfSearch
    {
        public int Id { get; set; }

        public string Number { get; set; }
        public int UserKey { get; set; }

        public List<TriggeringByNumber> TriggeringsByNumber { get; set; }

        

    }
}
