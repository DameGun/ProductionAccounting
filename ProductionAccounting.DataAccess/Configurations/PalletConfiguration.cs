﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductionAccounting.Core.Entities;

namespace ProductionAccounting.DataAccess.Configurations
{
	public class PalletConfiguration : IEntityTypeConfiguration<Pallet>
	{
		public void Configure(EntityTypeBuilder<Pallet> builder)
		{
			builder
				.ToTable("pallet");

			builder
				.Property(p => p.Barcode)
				.HasColumnName("barcode");
			builder
				.Property(b => b.Weight)
				.HasColumnName("weight");
			builder
				.Property(b => b.Boxes)
				.HasColumnName("boxes");
			builder
				.Property(b => b.InvoiceNo)
				.HasColumnName("invoice_no");

			builder.HasKey(p => p.Barcode);

			builder
				.HasOne(p => p.Invoice)
				.WithMany(i => i.Pallets)
				.HasForeignKey(p => p.InvoiceNo);
		}
	}
}