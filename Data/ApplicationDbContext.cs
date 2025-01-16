using Microsoft.EntityFrameworkCore;
using URLCutter.Models;

namespace URLCutter.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ShortURL> ShortURLs { get; set; }
    }
}
