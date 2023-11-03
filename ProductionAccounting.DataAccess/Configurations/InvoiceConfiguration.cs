using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductionAccounting.Core.Entities;

namespace ProductionAccounting.DataAccess.Configurations
{
	public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
	{
		public void Configure(EntityTypeBuilder<Invoice> builder)
		{
			builder
				.ToTable("invoice");

			builder
				.Property(i => i.InvoiceNo)
				.HasColumnName("invoice_no");
			builder
				.Property(i => i.Sender)
				.HasColumnName("sender");
			builder
				.Property(i => i.Recipient)
				.HasColumnName("recipient");
			builder
				.Property(i => i.Date)
				.HasColumnName("date");
			builder
				.Property(b => b.TotalCost)
				.HasColumnName("total_cost");

			builder
				.HasKey(i => i.InvoiceNo);
		}
	}
}
