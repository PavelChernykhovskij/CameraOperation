namespace CameraOperation.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        //public List<RuleOfSearch> RulesOfSearch { get; set; }


        public List<RuleOfSearchByNumber> RulesOfSearchByNumber { get; set; }
        public List<RuleOfSearchBySpeed> RulesOfSearchBySpeed { get; set; }
    }
}
