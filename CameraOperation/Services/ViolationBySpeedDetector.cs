using CamerOperationClassLibrary.Models;
using CamerOperationClassLibrary.EntityFramework.Repositories;

namespace CamerOperationClassLibrary.Services
{
    public class ViolationBySpeedDetector : IViolationDetector
    {
        private readonly IRuleOfSearchRepository<RuleOfSearchBySpeed> _ruleOfSearchBySpeed;
        private readonly IRepository<Fixation> _fixation;
        private readonly IRepository<TriggeringBySpeed> _triggeringBySpeed;
        private readonly IRepository<User> _user;

        public ViolationBySpeedDetector(IRuleOfSearchRepository<RuleOfSearchBySpeed> ruleOfSearchBySpeed, IRepository<User> user, IRepository<Fixation> fixation, IRepository<TriggeringBySpeed> triggeringBySpeed)
        {
            _ruleOfSearchBySpeed = ruleOfSearchBySpeed;
            _fixation = fixation;
            _triggeringBySpeed = triggeringBySpeed;
            _user = user;

        }
        public void ViolationDetect(Fixation fixation)
        {
            var rbs = _ruleOfSearchBySpeed.ReadAll().ToList();


            if (fixation != null)
            {
                foreach (RuleOfSearchBySpeed violation in rbs)
                {
                    if (fixation.CarSpeed >= violation.Speed)
                    {
                        Fixation fixation1 = _fixation.Read().Where(f => f.Id == fixation.Id).FirstOrDefault();
                        
                        RuleOfSearchBySpeed ruleOfSearchBySpeed = _ruleOfSearchBySpeed.ReadAll().Where(r => r.Id == violation.Id).FirstOrDefault();

                        TriggeringBySpeed triggeringBySpeed = new TriggeringBySpeed() { CarSpeed = fixation.CarSpeed, FixationDate = fixation.FixationDate, Fixation = fixation1, RuleOfSearchBySpeedId = ruleOfSearchBySpeed.Id, RuleOfSearchBySpeed = ruleOfSearchBySpeed};
                        _triggeringBySpeed.Create(triggeringBySpeed);

                        //Console.WriteLine($"({triggeringBySpeed.Id}, {triggeringBySpeed.CarSpeed}, {triggeringBySpeed.RuleOfSearchBySpeedId}, {triggeringBySpeed.FixationDate}, {triggeringBySpeed.Fixation.Id}, {triggeringBySpeed.RuleOfSearchBySpeed.Speed} )");
                    }
                }
            }
        }
    }
}
