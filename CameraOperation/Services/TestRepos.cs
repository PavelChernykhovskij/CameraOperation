using CameraOperation.Models;
using CameraOperation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using CameraOperation.EntityFramework.Repositories;
using CameraOperation.EntityFramework;

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

            Fixation fixation = new Fixation { FixationDate = DateTime.Now, CarNumber = "123", CarSpeed = 33333 };
            _fixationRepo.Create(fixation);

            foreach (Fixation f in _fixationRepo.Read())
            {
                Console.WriteLine($"Номер автомбиля: {f.CarNumber} Дата фиксации: {f.FixationDate} Скорость автомобиля: {f.CarSpeed}");
            }

            foreach (User u in _userRepo.Read())
            {
                Console.WriteLine($" Логин: {u.Login}\n Пароль: {u.Password}\n ФИО: {u.Name}\n Список правил: ");
            }

            User userDicaprio = _userRepo.Read().FirstOrDefault(u => u.Name == "LeonardoDicaprio");
            User userD = new User { Name = userDicaprio.Name, Login = userDicaprio.Login, Password = userDicaprio.Password };


            RuleOfSearchByNumber ruleOfSearchByNumber2 = new RuleOfSearchByNumber { DateOfCreate = DateTime.Now, Number = "123456", User = userD };

            _ruleOfSearchByNumberRepo.Create(ruleOfSearchByNumber2);

            foreach (RuleOfSearchByNumber rbn in _ruleOfSearchByNumberRepo.ReadAll())
            {
                Console.WriteLine($"   Правило для номера { rbn.Number}");
            }
            _ruleOfSearchByNumberRepo.Delete(_ruleOfSearchByNumberRepo.ReadAll().FirstOrDefault(rbn => rbn.Number == "123456").Id);

            foreach (RuleOfSearchByNumber rbn in _ruleOfSearchByNumberRepo.ReadAll())
            {
                Console.WriteLine($"   Правило для номера { rbn.Number}");
            }

            Console.WriteLine(_ruleOfSearchByNumberRepo.ReadOne().Number);

            foreach (TriggeringByNumber tbn in _triggeringByNumberRepo.Read())
            {
                Console.WriteLine($"   Сработка для номера { tbn.CarNumber} Дата сработки {tbn.FixationDate} ");
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
