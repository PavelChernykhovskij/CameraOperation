﻿using CameraOperation.Models;
using CameraOperation;
using Microsoft.EntityFrameworkCore;

namespace CameraOperation.Services
{
    public class TestRepos : IHostedService
    {
        public Task StartAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Timed Hosted Service running.");
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
                Console.WriteLine("Create");

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
                db.Fixations.AddRange(fixation1, fixation2, fixation3, fixation4);
                db.TriggeringByNumbers.AddRange(triggeringByNumber1, triggeringByNumber2);
                db.TriggeringBySpeeds.AddRange(triggeringBySpeed1, triggeringBySpeed2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены\n");

                Console.WriteLine("Read\n");
                Console.WriteLine("Пользователи:");

                var users = db.Users.Include(rbn => rbn.RulesOfSearchByNumber).Include(rbs => rbs.RulesOfSearchBySpeed).ToList();
               
                foreach (User u in users)
                {

                    Console.WriteLine($"Логин: {u.Login}\nПароль: {u.Password}\nФИО: {u.Name}\nСписок правил: " );

                    Console.WriteLine("По номеру: ");
                    foreach (RuleOfSearchByNumber rb in u.RulesOfSearchByNumber)
                    {
                        Console.WriteLine($"Правило для номера { rb.Number} ");
                    }
                    Console.WriteLine("По скорости: ");
                    foreach (RuleOfSearchBySpeed rb in u.RulesOfSearchBySpeed)
                    {
                        Console.WriteLine($"Правило для скорости { rb.Speed } ");
                    }
                    
                }

                Console.WriteLine("\nПравила розыска:");

                var rbs = db.RulesOfSearchBySpeed.ToList();
                var rbn = db.RulesOfSearchByNumber.ToList();

                Console.WriteLine("По номеру: ");
                foreach (RuleOfSearchByNumber rb in rbn)
                {
                    Console.WriteLine($"Пользователь {rb.User.Name} Дата создания {rb.DateOfCreate} Правило для номера { rb.Number} ");
                }
                Console.WriteLine("По скорости: ");
                foreach (RuleOfSearchBySpeed rb in rbs)
                {
                    Console.WriteLine($"Пользователь {rb.User.Name} Дата создания {rb.DateOfCreate} Правило для номера { rb.Speed} ");
                }

                Console.WriteLine("\nСработки:");

                var tbn = db.TriggeringByNumbers.ToList();
                var tbs = db.TriggeringBySpeeds.ToList();

                Console.WriteLine("По номеру: ");
                foreach (TriggeringByNumber tr in tbn)
                {
                    Console.WriteLine($"Номер автомобиля: {tr.Fixation.CarNumber} - Дата фиксации {tr.Fixation.FixationDate} ");
                }
                Console.WriteLine("По скорости: ");
                foreach (TriggeringBySpeed tr in tbs)
                {
                    Console.WriteLine($"Скорость автомобиля: {tr.Fixation.CarSpeed} - Дата фиксации {tr.Fixation.FixationDate} ");
                }

                Console.WriteLine("\nФиксациии:");
                
                var fix = db.Fixations.ToList();
                foreach (Fixation f in fix)
                {
                    Console.WriteLine($"Номер автомбиля: {f.CarNumber} Дата фиксации: {f.FixationDate} Скорость автомобиля: {f.CarSpeed}");
                }

                Console.WriteLine("Update\n");
                Console.WriteLine("Измененные данные правил розыска:");

                RuleOfSearchByNumber rbn1 = db.RulesOfSearchByNumber.FirstOrDefault(rbn => rbn.Number == "231");
                if (rbn1 != null)
                {
                    rbn1.Number = "3333";
                    db.SaveChanges();
                }
                RuleOfSearchBySpeed rbs1 = db.RulesOfSearchBySpeed.FirstOrDefault(rbn => rbn.Speed == 123);
                if (rbs1 != null)
                {
                    rbs1.Speed = 60;
                    db.SaveChanges();
                }

                foreach (RuleOfSearchByNumber rb in rbn)
                {
                    Console.WriteLine($"Пользователь {rb.User.Name} Дата создания {rb.DateOfCreate} Правило для номера { rb.Number} ");
                }
                Console.WriteLine("По скорости: ");
                foreach (RuleOfSearchBySpeed rb in rbs)
                {
                    Console.WriteLine($"Пользователь {rb.User.Name} Дата создания {rb.DateOfCreate} Правило для номера { rb.Speed} ");
                }



            }

            

           

            Console.WriteLine("After delete");


            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Timed Hosted Service is stopping.");

            return Task.CompletedTask;
        }

    }
}
