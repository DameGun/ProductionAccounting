using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductionAccounting.Core.Entities;
using ProductionAccounting.Core.Aggregations;

namespace ProductionAccounting.DataAccess.Configurations
{
	public class ProductUnitConfiguration : IEntityTypeConfiguration<ProductUnit>
	{
		public void Configure(EntityTypeBuilder<ProductUnit> builder)
		{
			builder
				.ToTable("product_unit");

			builder
				.HasKey(u => u.Serial);

			builder
				.Property(u => u.Serial)
				.HasColumnName("serial");
			builder
				.Property(u => u.ProductId)
				.HasColumnName("product_id");
			builder
				.Property(u => u.Date)
				.HasColumnName("date");
			builder
				.Property(u => u.Expire)
				.HasColumnName("expire");
			builder
				.Property(u => u.BoxBarcode)
				.HasColumnName("box_barcode");

			builder
				.HasOne(u => u.Product)
				.WithMany(p => p.ProductUnits)
				.HasForeignKey(u => u.ProductId);

			builder
				.HasOne(u => u.Box)
				.WithMany(b => b.ProductUnits)
				.HasForeignKey(u => u.BoxBarcode);
		}
	}
}
