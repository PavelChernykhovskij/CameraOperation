namespace CameraOperation.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        //public List<RuleOfSearch> RulesOfSearch { 
        //    get => RulesOfSearchByNumber.Select(_ => _ as RuleOfSearch).Union(RulesOfSearchBySpeed.Select(_ => _ as RuleOfSearch)).ToList(); 
        //}


        public List<RuleOfSearchByNumber> RulesOfSearchByNumber { get; set; }
        public List<RuleOfSearchBySpeed> RulesOfSearchBySpeed { get; set; }
    }
}
