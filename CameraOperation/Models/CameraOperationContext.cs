using Microsoft.EntityFrameworkCore;

namespace CameraOperation.Models
{
    
    public class CameraOperationContext : DbContext
    {
        public CameraOperationContext(DbContextOptions<CameraOperationContext> options)
            : base(options)
        { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
    }
}
