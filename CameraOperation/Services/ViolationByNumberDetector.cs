using CamerOperationClassLibrary.Models;
using CamerOperationClassLibrary.EntityFramework.Repositories;

namespace CamerOperationClassLibrary.Services
{
    public class ViolationByNumberDetector
        : ViolationDetector<RuleOfSearchByNumber, TriggeringByNumber>
    {
        public ViolationByNumberDetector(
            IRepository<RuleOfSearchByNumber> ruleRepository,
            IRepository<TriggeringByNumber> triggeringRepository)
            : base(ruleRepository, triggeringRepository) { }

        public override TriggeringByNumber? GetTriggering(Fixation fixation, RuleOfSearchByNumber rule)
        {
            return rule.Number == fixation.CarNumber
                ? new TriggeringByNumber
                {
                    FixationId = fixation.Id,
                    RuleOfSearchByNumberId = rule.Id,
                    FixationDate = fixation.FixationDate,
                    CarNumber = fixation.CarNumber
                }
                : null;
        }
    }
}
