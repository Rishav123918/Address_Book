using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DataContext() { }

        public DbSet<Person> Person { get; set; }
    }
}
