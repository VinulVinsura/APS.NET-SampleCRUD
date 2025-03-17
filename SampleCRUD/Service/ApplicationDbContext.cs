
using Microsoft.EntityFrameworkCore;
using SampleCRUD.Model;

namespace SampleCRUD.Service
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
