using CameraOperation.Models;
using CameraOperation.EntityFramework.Repositories;

namespace CameraOperation.Services
{
    public class ViolationDetector : IConcreteViolationDetector
    {
        private readonly IEnumerable<IRuleOfSearchRepository<RuleOfSearchByNumber>> _rulesOfSearchByNumber;
        private readonly IEnumerable<IRuleOfSearchRepository<RuleOfSearchBySpeed>> _rulesOfSearchBySpeed;

        public ViolationDetector(IEnumerable<IRuleOfSearchRepository<RuleOfSearchByNumber>> rulesOfSearchByNumber,
            IEnumerable<IRuleOfSearchRepository<RuleOfSearchBySpeed>> rulesOfSearchBySpeed)
        {
            _rulesOfSearchByNumber = rulesOfSearchByNumber;
            _rulesOfSearchBySpeed = rulesOfSearchBySpeed;
        }
        public void ViolationDetect(Fixation fixation)
        {
            foreach (var rule in _rulesOfSearchByNumber)
            {
                rule.Detect(fixation);
            }

            foreach (var rule in _rulesOfSearchBySpeed)
            {
                rule.Detect(fixation);
            }
        }
    }
}
