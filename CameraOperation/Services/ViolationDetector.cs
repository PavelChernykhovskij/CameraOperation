using CamerOperationClassLibrary.Models;
using CamerOperationClassLibrary.EntityFramework.Repositories;

namespace CamerOperationClassLibrary.Services
{
    public abstract class ViolationDetector<TRule, TTrig> : IViolationDetector
    {
        protected readonly IRepository<TRule> _ruleRepository;
        protected readonly IRepository<TTrig> _triggeringRepository;

        public ViolationDetector(
            IRepository<TRule> ruleRepository,
            IRepository<TTrig> triggeringRepository)
        {
            _ruleRepository = ruleRepository;
            _triggeringRepository = triggeringRepository;
        }

        public abstract TTrig? GetTriggering(Fixation fixation, TRule rule);

        public void ViolationDetect(Fixation fixation)
        {
            if (fixation == null) return;

            foreach (var rule in _ruleRepository.Read())
            {
                var triggering = GetTriggering(fixation, rule);
                if (triggering != null)
                {
                    _triggeringRepository.Create(triggering);
                }
            }
        }
    }
}
