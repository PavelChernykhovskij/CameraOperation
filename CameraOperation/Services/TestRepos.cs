using CameraOperation.Models;
using CameraOperation.EntityFramework.Repositories;

namespace CameraOperation.Services
{
    public class TestRepos : IHostedService
    {
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Fixation> _fixationRepo;
        private readonly IRuleOfSearchRepository<RuleOfSearchByNumber> _ruleOfSearchByNumberRepo;
        private readonly IRuleOfSearchRepository<RuleOfSearchBySpeed> _ruleOfSearchBySpeedRepo;
        private readonly IRepository<TriggeringByNumber> _triggeringByNumberRepo;
        private readonly IRepository<TriggeringBySpeed> _triggeringBySpeedRepo;
        public TestRepos(IRepository<User> userRepo, 
            IRepository<Fixation> fixationRepo,
            IRuleOfSearchRepository<RuleOfSearchByNumber> ruleOfSearchByNumberRepo, 
            IRuleOfSearchRepository<RuleOfSearchBySpeed> ruleOfSearchBySpeedRepo,
            IRepository<TriggeringByNumber> triggeringByNumberRepo,
            IRepository<TriggeringBySpeed> triggeringBySpeedRepo)
        {
            _userRepo = userRepo;
            _fixationRepo = fixationRepo;
            _ruleOfSearchByNumberRepo = ruleOfSearchByNumberRepo;
            _ruleOfSearchBySpeedRepo = ruleOfSearchBySpeedRepo;
            _triggeringByNumberRepo = triggeringByNumberRepo;
            _triggeringBySpeedRepo = triggeringBySpeedRepo;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {

            foreach (Fixation f in _fixationRepo.Read())
            {
                Console.WriteLine($"Номер автомбиля: {f.CarNumber} Дата фиксации: {f.FixationDate} Скорость автомобиля: {f.CarSpeed}");
            }

            foreach (RuleOfSearchByNumber rbn in _ruleOfSearchByNumberRepo.ReadAll())
            {
                Console.WriteLine($"   Правило для номера { rbn.Number}");
            }
          
            foreach (RuleOfSearchBySpeed rbs in _ruleOfSearchBySpeedRepo.ReadAll())
            {
                Console.WriteLine($"   Правило для скорости { rbs.Speed}");
            }

            foreach (TriggeringByNumber tbn in _triggeringByNumberRepo.Read())
            {
                Console.WriteLine($"   Сработка для номера { tbn.CarNumber} Дата сработки {tbn.FixationDate} ");
            }

            foreach (TriggeringBySpeed tbs in _triggeringBySpeedRepo.Read())
            {
                Console.WriteLine($"   Сработка для скорости { tbs.CarSpeed} Дата сработки {tbs.FixationDate} Скорость {tbs.RuleOfSearchBySpeed.Speed}");
            }

            Console.WriteLine();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Timed Hosted Service is stopping.");

            return Task.CompletedTask;
        }

    }
}
