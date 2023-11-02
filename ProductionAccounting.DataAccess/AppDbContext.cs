using Microsoft.EntityFrameworkCore;
using ProductionAccounting.DataAccess.Aggregations;
using ProductionAccounting.DataAccess.Entities;

namespace ProductionAccounting.DataAccess
{
	public class AppDbContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Box> Boxes { get; set; }
		public DbSet<Pallet> Pallets { get; set; }
		public DbSet<Invoice> Invoices { get; set; }
		public DbSet<ProductionApplication> Applications { get; set; }
		public DbSet<ProductUnit> ProductUnits { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
	}
}
