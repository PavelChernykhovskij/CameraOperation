using CameraOperation;
using CameraOperation.Models;
using Microsoft.EntityFrameworkCore;

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
