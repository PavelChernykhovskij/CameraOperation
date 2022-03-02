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

            Fixation fixation = new Fixation { FixationDate = DateTime.Now, CarNumber = "123", CarSpeed = 777 };
            this._fixationRepo.Create(fixation);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Timed Hosted Service is stopping.");

            return Task.CompletedTask;
        }

    }
}
