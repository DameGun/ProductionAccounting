using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductionAccounting.Core.Entities;

namespace ProductionAccounting.DataAccess.Configurations
{
	public class ProductionApplicationConfiguration : IEntityTypeConfiguration<ProductionApplication>
	{
		public void Configure(EntityTypeBuilder<ProductionApplication> builder)
		{
			builder
				.ToTable("production_application");

			builder
				.Property(a => a.Id)
				.HasColumnName("id");
			builder
				.Property(a => a.ProductId)
				.HasColumnName("product_id");
			builder
				.Property(a => a.PackagesInBox)
				.HasColumnName("packages_in_box");
			builder
				.Property(a => a.BoxesInPallet)
				.HasColumnName("boxes_in_pallet");
			builder
				.Property(a => a.TotalUnits)
				.HasColumnName("units_total");
			builder
				.Property(a => a.TotalBoxes)
				.HasColumnName("box_total");
			builder
				.Property(a => a.TotalPallets)
				.HasColumnName("pallets_total");
			builder
				.Property(a => a.LastBoxGuid)
				.HasColumnName("last_box_guid");
			builder
				.Property(a => a.LastPalletGuid)
				.HasColumnName("last_pallet_guid");
			builder
				.Property(a => a.ProdDate)
				.HasColumnName("prod_date");
			builder
				.Property(a => a.ExpDate)
				.HasColumnName("exp_date");
			builder
				.Property(a => a.CurrentApplicationState)
				.HasColumnName("current_application_state")
				.HasColumnType("text");

			builder
				.HasOne(a => a.Product)
				.WithMany(p => p.Applications)
				.HasForeignKey(a => a.ProductId);

			builder
				.Navigation(a => a.Product)
				.AutoInclude();
		}
	}
}
