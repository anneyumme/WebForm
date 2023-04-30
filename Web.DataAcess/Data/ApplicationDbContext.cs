using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.DataAccess.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
		public DbSet<Brand> Brands { get; set; }
		public DbSet<Product> Products { get; set; }
	}
}
