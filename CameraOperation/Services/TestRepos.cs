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
        private readonly IUserRepository<User> _userRepo;
        private readonly IFixationRepository<Fixation> _fixationRepo;
        private readonly IRuleOfSearchByNumberRepository<RuleOfSearchByNumber> _ruleOfSearchByNumberRepo;
        private readonly IRuleOfSearchBySpeedRepository<RuleOfSearchBySpeed> _ruleOfSearchBySpeedRepo;
        private readonly ITriggeringByNumberRepository<TriggeringByNumber> _triggeringByNumberRepo;
        private readonly ITriggeringBySpeedRepository<TriggeringBySpeed> _triggeringBySpeedRepo;
        public TestRepos(IUserRepository<User> userRepo, 
            IFixationRepository<Fixation> fixationRepo,
            IRuleOfSearchByNumberRepository<RuleOfSearchByNumber> ruleOfSearchByNumberRepo, 
            IRuleOfSearchBySpeedRepository<RuleOfSearchBySpeed> ruleOfSearchBySpeedRepo,
            ITriggeringByNumberRepository<TriggeringByNumber> triggeringByNumberRepo,
            ITriggeringBySpeedRepository<TriggeringBySpeed> triggeringBySpeedRepo)
        {
            _userRepo = userRepo;
            _fixationRepo = fixationRepo;
            _ruleOfSearchByNumberRepo = ruleOfSearchByNumberRepo;
            _ruleOfSearchBySpeedRepo = ruleOfSearchBySpeedRepo;
            _triggeringByNumberRepo = triggeringByNumberRepo;
            _triggeringByNumberRepo = triggeringByNumberRepo;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Timed Hosted Service running.");

            TestRepos testRepos = new TestRepos(_userRepo, _fixationRepo, _ruleOfSearchByNumberRepo, _ruleOfSearchBySpeedRepo, _triggeringByNumberRepo, _triggeringBySpeedRepo);
            Fixation fixation1 = new Fixation { FixationDate = DateTime.Now, CarNumber = "123", CarSpeed = 777 };

            testRepos._fixationRepo.Create(fixation1);

            Console.WriteLine(testRepos._fixationRepo.Create(fixation1));
            foreach (Fixation f in testRepos._fixationRepo.Read())
            {
                Console.WriteLine($"Номер автомбиля: {f.CarNumber} Дата фиксации: {f.FixationDate} Скорость автомобиля: {f.CarSpeed}");
            }

            foreach (User u in testRepos._userRepo.Read())
            {
                Console.WriteLine($" Логин: {u.Login}\n Пароль: {u.Password}\n ФИО: {u.Name}\n Список правил: ");
            }

            User userDicaprio = _userRepo.Read().FirstOrDefault(u => u.Name == "LeonardoDicaprio");
            User userD = new User { Name = userDicaprio.Name, Login = userDicaprio.Login, Password = userDicaprio.Password };


            RuleOfSearchByNumber ruleOfSearchByNumber2 = new RuleOfSearchByNumber { DateOfCreate = DateTime.Now, Number = "66633", User = userD };

            testRepos._ruleOfSearchByNumberRepo.Create(ruleOfSearchByNumber2);

            foreach (RuleOfSearchByNumber rbn in testRepos._ruleOfSearchByNumberRepo.ReadAll())
            {
                Console.WriteLine($"   Правило для номера { rbn.Number}");
            }
            testRepos._ruleOfSearchByNumberRepo.Delete(testRepos._ruleOfSearchByNumberRepo.ReadAll().FirstOrDefault(rbn => rbn.Number == "66633").Id);

            foreach (RuleOfSearchByNumber rbn in testRepos._ruleOfSearchByNumberRepo.ReadAll())
            {
                Console.WriteLine($"   Правило для номера { rbn.Number}");
            }

            Console.WriteLine(testRepos._ruleOfSearchByNumberRepo.ReadOne().Number);

            foreach (TriggeringByNumber tbn in testRepos._triggeringByNumberRepo.Read())
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
