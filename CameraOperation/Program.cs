using CameraOperation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var options = new DbContextOptionsBuilder<CameraOperationContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

var context = new CameraOperationContext(options);

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();