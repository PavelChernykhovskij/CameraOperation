using CameraOperation;
using CameraOperation.Models;
using Microsoft.EntityFrameworkCore;

var builder = new ConfigurationBuilder();
// ��������� ���� � �������� ��������
builder.SetBasePath(Directory.GetCurrentDirectory());
// �������� ������������ �� ����� appsettings.json
builder.AddJsonFile("appsettings.json");
// ������� ������������
var config = builder.Build();
// �������� ������ �����������
string connectionString = config.GetConnectionString("DefaultConnection");

var optionsBuilder = new DbContextOptionsBuilder<CameraOperationContext>();
var options = optionsBuilder
    .UseSqlServer(connectionString)
    .Options;

using (CameraOperationContext db = new(options))
{
    // ������� ��� ������� User
    User user1 = new User { Name = "Tom", Login = "Boy", Password = "123" };
    User user2 = new User { Name = "Alice", Login = "Girl", Password = "321" };

    // ��������� �� � ��
    db.Users.Add(user1);
    db.Users.Add(user2);
    db.SaveChanges();
    Console.WriteLine("������� ������� ���������");

    // �������� ������� �� �� � ������� �� �������
    var users = db.Users.ToList();
    Console.WriteLine("������ ��������:");
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
    Console.WriteLine("�������� ������");
}

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .UseContentRoot(AppDomain.CurrentDomain.BaseDirectory)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
