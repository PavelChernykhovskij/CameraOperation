using CameraOperation.Models;
using Microsoft.EntityFrameworkCore;



var options = new DbContextOptionsBuilder<CameraOperationContext>()
   .UseInMemoryDatabase(databaseName: "Test")
   .Options;

using (var context = new CameraOperationContext(options))
{
    var customer = new Customer
    {
        FirstName = "Elizabeth",
        LastName = "Lincoln",
        Address = "23 Tsawassen Blvd."
    };

    context.Customers.Add(customer);
    context.SaveChanges();

}
