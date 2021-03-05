using Microsoft.EntityFrameworkCore;

namespace Zags.Web.Models
{
    public class ZagsDbContext : DbContext
    {
        public ZagsDbContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Person> People { get; set; }
    }
}
