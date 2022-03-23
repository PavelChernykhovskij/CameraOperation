using Microsoft.Extensions.Hosting;
using System.Text;
using Newtonsoft.Json;

namespace RequestSender
{
    internal class Sender : IHostedService
    {
        private Timer _timer;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(SendAsync, null, 0, 10000);
            
            Thread.Sleep(1000);
            return Task.CompletedTask;
        }

        private void SendAsync(object? state)
        {
            DateTime now = DateTime.Now;
            Random rnd = new Random();
            int speed = rnd.Next(1, 120);
            string number = rnd.Next(222, 444).ToString();
            var person = new FixationDto() { CarNumber = number, CarSpeed = speed, FixationDate = now };
            var json = JsonConvert.SerializeObject(person);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:7037/api/Fixation/Create/";
            using var client = new HttpClient();

            var response = client.PostAsync(url, data).Result;

            var result = response.Content.ReadAsStringAsync().Result.ToString();
            Console.WriteLine(result);
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            //New Timer does not have a stop. 
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
