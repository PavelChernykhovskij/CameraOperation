using CameraOperation;
using CameraOperation.Models;
using Microsoft.EntityFrameworkCore;

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
    // создаем два объекта User
    User user1 = new User { Name = "Tom", Login = "Boy", Password = "123" };
    User user2 = new User { Name = "Alice", Login = "Girl", Password = "321" };

    // добавляем их в бд
    db.Users.Add(user1);
    db.Users.Add(user2);
    db.SaveChanges();
    Console.WriteLine("Объекты успешно сохранены");

    // получаем объекты из бд и выводим на консоль
    var users = db.Users.ToList();
    Console.WriteLine("Список объектов:");
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - ( {u.Login} : {u.Password} )");
    }
}
Console.Read();

try
{
    using var host = CreateHostBuilder(args).Build();
    await host.StartAsync();
    await host.WaitForShutdownAsync();

}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
finally
{
    Console.WriteLine("Завершил работу");
}

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .UseContentRoot(AppDomain.CurrentDomain.BaseDirectory)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
