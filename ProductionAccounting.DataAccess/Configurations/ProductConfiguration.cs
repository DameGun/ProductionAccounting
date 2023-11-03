using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductionAccounting.Core.Aggregations;

namespace ProductionAccounting.DataAccess.Configurations
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder
				.ToTable("product");

			builder
				.Property(p => p.Id)
				.HasColumnName("id");
			builder 
				.Property(p => p.Name)
				.HasColumnName("name");
			builder
				.Property(p => p.Weight)
				.HasColumnName("weight");
			builder
				.Property(p => p.CategoryId)
				.HasColumnName("category_id");
			builder
				.Property(p => p.Cost)
				.HasColumnName("cost");

			builder
				.HasOne(p => p.Category)
				.WithMany(c => c.Products)
				.HasForeignKey(p => p.CategoryId);

			builder
				.Navigation(p => p.Category)
				.AutoInclude();
		}
	}
}
