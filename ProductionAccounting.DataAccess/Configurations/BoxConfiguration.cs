using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductionAccounting.Core.Entities;

namespace ProductionAccounting.DataAccess.Configurations
{
	public class BoxConfiguration : IEntityTypeConfiguration<Box>
	{
		public void Configure(EntityTypeBuilder<Box> builder)
		{
			builder
				.ToTable("box");

			builder
				.Property(b => b.Barcode)
				.HasColumnName("barcode");
			builder
				.Property(b => b.Weight)
				.HasColumnName("weight");
			builder
				.Property(b => b.Packages)
				.HasColumnName("packages");
			builder
				.Property(b => b.PalletBarcode)
				.HasColumnName("pallet_barcode");
			builder
				.Property(b => b.InvoiceNo)
				.HasColumnName("invoice_no");

			builder
				.HasKey(b => b.Barcode);

			//builder
			//	.HasOne(b => b.Pallet)
			//	.WithMany(p => p.BoxesInside)
			//	.HasForeignKey(b => b.PalletBarcode);

			builder
				.HasOne(b => b.Invoice)
				.WithMany(i => i.Boxes)
				.HasForeignKey(b => b.InvoiceNo);
		}
	}
}
