using CameraOperation.Models;
using CameraOperation;
using Microsoft.EntityFrameworkCore;

namespace CameraOperation.Services
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private readonly ILogger<TimedHostedService> _logger;
        private Timer _timer = null!;

        
        public TimedHostedService(ILogger<TimedHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");
            //получаем строку подключения
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<CameraOperationContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            

            using (CameraOperationContext db = new(options))
            {
                _logger.LogInformation("Create");

                RuleOfSearchByNumber ruleOfSearchByNumber1 = new RuleOfSearchByNumber { User = db.Users.FirstOrDefault(), DateOfCreate = DateTime.Today, Number = "231" };

                RuleOfSearchByNumber ruleOfSearchByNumber2 = new RuleOfSearchByNumber { User = db.Users.FirstOrDefault(), DateOfCreate = DateTime.Today, Number = "2222" };

                RuleOfSearchBySpeed ruleOfSearchBySpeed1 = new RuleOfSearchBySpeed { User = db.Users.FirstOrDefault(), DateOfCreate = DateTime.Today, Speed = 123 };

                RuleOfSearchBySpeed ruleOfSearchBySpeed2 = new RuleOfSearchBySpeed { User = db.Users.FirstOrDefault(), DateOfCreate = DateTime.Today, Speed = 90 };

                Fixation fixation1 = new Fixation { FixationDate = DateTime.Now, CarNumber = "231", CarSpeed = 123 };
                Fixation fixation2 = new Fixation { FixationDate = DateTime.Now, CarNumber = "2222", CarSpeed = 133 };
                Fixation fixation3 = new Fixation { FixationDate = DateTime.Now, CarNumber = "132", CarSpeed = 104 };
                Fixation fixation4 = new Fixation { FixationDate = DateTime.Now, CarNumber = "43", CarSpeed = 100 };

                TriggeringByNumber triggeringByNumber1 = new TriggeringByNumber { Fixation = fixation1, CarNumber = fixation1.CarNumber, FixationDate = fixation1.FixationDate, RuleOfSearchByNumber = ruleOfSearchByNumber1 };
                TriggeringByNumber triggeringByNumber2 = new TriggeringByNumber { Fixation = fixation2, CarNumber = fixation2.CarNumber, FixationDate = fixation2.FixationDate, RuleOfSearchByNumber = ruleOfSearchByNumber2 };
                TriggeringBySpeed triggeringBySpeed1 = new TriggeringBySpeed { Fixation = fixation3, CarSpeed = fixation3.CarSpeed, FixationDate = fixation3.FixationDate, RuleOfSearchBySpeed = ruleOfSearchBySpeed1 };
                TriggeringBySpeed triggeringBySpeed2 = new TriggeringBySpeed { Fixation = fixation4, CarSpeed = fixation4.CarSpeed, FixationDate = fixation4.FixationDate, RuleOfSearchBySpeed = ruleOfSearchBySpeed1 };

                db.RulesOfSearchByNumber.AddRange(ruleOfSearchByNumber1, ruleOfSearchByNumber2);
                db.RulesOfSearchBySpeed.AddRange(ruleOfSearchBySpeed1, ruleOfSearchBySpeed2);

                db.Fixations.AddRange(fixation1,fixation2,fixation3,fixation4);
                db.TriggeringByNumbers.AddRange(triggeringByNumber1,triggeringByNumber2);
                db.TriggeringBySpeeds.AddRange(triggeringBySpeed1,triggeringBySpeed2);
                db.SaveChanges();
                _logger.LogInformation("Объекты успешно сохранены");

                _logger.LogInformation("Read");

                var trn = db.TriggeringByNumbers.ToList();

                foreach (TriggeringByNumber tre in trn)
                {
                    _logger.LogInformation($"{tre.Id}.{tre.Fixation.CarNumber} - ( {tre.Fixation.FixationDate} )");
                }

                var tbs = db.TriggeringBySpeeds.ToList();

                foreach (TriggeringBySpeed tre1 in tbs)
                {
                    _logger.LogInformation($"{tre1.Id}.{tre1.Fixation.CarSpeed} - ( {tre1.Fixation.FixationDate} )");
                }

            }

            _logger.LogInformation("Update");

            _logger.LogInformation("Delete");

            _logger.LogInformation("After delete");


            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            _logger.LogInformation("___________________________________");
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
