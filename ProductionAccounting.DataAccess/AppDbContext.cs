using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductionAccounting.Core.Aggregations;
using ProductionAccounting.DataAccess.Configurations;
using ProductionAccounting.Core.Entities;

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


		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProductConfiguration());
			modelBuilder.ApplyConfiguration(new ProductUnitConfiguration());
			modelBuilder.ApplyConfiguration(new BoxConfiguration());
			modelBuilder.ApplyConfiguration(new PalletConfiguration());
			modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
			modelBuilder.ApplyConfiguration(new CategoryConfiguration());
			modelBuilder.ApplyConfiguration(new ProductionApplicationConfiguration());
		}
	}
}
