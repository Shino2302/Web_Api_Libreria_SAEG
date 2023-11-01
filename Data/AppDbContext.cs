using Libreria_SAEG.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace Libreria_SAEG.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
    }
}
