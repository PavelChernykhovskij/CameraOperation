using CamerOperationClassLibrary.Models;
using CamerOperationClassLibrary.EntityFramework.Repositories;

namespace CamerOperationClassLibrary.Services
{
    public class ViolationBySpeedDetector
        : ViolationDetector<RuleOfSearchBySpeed, TriggeringBySpeed>
    {
        public ViolationBySpeedDetector(
            IRepository<RuleOfSearchBySpeed> ruleRepository,
            IRepository<TriggeringBySpeed> triggeringRepository)
            : base(ruleRepository, triggeringRepository) { }

        public override TriggeringBySpeed? GetTriggering(Fixation fixation, RuleOfSearchBySpeed rule)
        {
            return fixation.CarSpeed > rule.Speed
                ? new TriggeringBySpeed
                {
                    FixationId = fixation.Id,
                    RuleOfSearchBySpeedId = rule.Id,
                    FixationDate = fixation.FixationDate,
                    CarSpeed = fixation.CarSpeed
                }
                : null;
        }
    }
}
