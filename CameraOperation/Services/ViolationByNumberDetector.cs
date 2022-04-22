using CamerOperationClassLibrary.Models;
using CamerOperationClassLibrary.EntityFramework.Repositories;

namespace CamerOperationClassLibrary.Services
{
    public class ViolationByNumberDetector : IViolationDetector
    {
        private readonly IRuleOfSearchRepository<RuleOfSearchByNumber> _ruleOfSearchByNumber;
        private readonly IRepository<Fixation> _fixation;
        private readonly IRepository<TriggeringByNumber> _triggeringByNumber;
        private readonly IRepository<User> _user;

        public ViolationByNumberDetector(IRuleOfSearchRepository<RuleOfSearchByNumber> ruleOfSearchByNumber, IRepository<User> user, IRepository<Fixation> fixation, IRepository<TriggeringByNumber> triggeringByNumber)
        {
            _ruleOfSearchByNumber = ruleOfSearchByNumber;
            _fixation = fixation;
            _triggeringByNumber = triggeringByNumber;
            _user = user; 
        }
        public void ViolationDetect(Fixation fixation)
        {
            var rbn = _ruleOfSearchByNumber.ReadAll();
            if (fixation != null)
            {
                foreach (RuleOfSearchByNumber violation in rbn)
                {
                    if (violation.Number == fixation.CarNumber)
                    {
                        Fixation fixation1 = _fixation.Read().Where(f => f.Id == fixation.Id).FirstOrDefault();
                        RuleOfSearchByNumber ruleOfSearchByNumber = _ruleOfSearchByNumber.ReadAll().Where(r => r.Id == violation.Id).FirstOrDefault();
                        TriggeringByNumber triggeringByNumber = new TriggeringByNumber() { CarNumber = fixation.CarNumber, FixationDate = fixation.FixationDate, RuleOfSearchByNumber = ruleOfSearchByNumber, RuleOfSearchByNumberId = ruleOfSearchByNumber.Id, Fixation = fixation1 };
                        _triggeringByNumber.Create(triggeringByNumber);
                        
                        //_fixation.Update(triggeringByNumber.Fixation);
                        //_ruleOfSearchByNumber.Update(triggeringByNumber.RuleOfSearchByNumber);
                        //_user.Update(triggeringByNumber.RuleOfSearchByNumber.User);
                    }
                }
            }

        }
    }
}
