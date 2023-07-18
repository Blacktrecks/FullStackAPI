using FullStack.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStack.API.Data
{
    public class FullStackDbContext : DbContext
    {
        public FullStackDbContext(DbContextOptions options) : base(options)
        {
        }

        //setare baza date Angajati
        public DbSet<Employee> Employees { get; set; }
        //setare baza date Useri
        public DbSet<User> USers{ get; set; }
    }
}
