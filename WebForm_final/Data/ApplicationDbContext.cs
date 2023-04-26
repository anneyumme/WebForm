using Microsoft.EntityFrameworkCore;
using WebForm_final.Models;

namespace WebForm_final.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Brand> Brands { get; set; }
    }
}
