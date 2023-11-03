using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductionAccounting.Core.Aggregations;

namespace ProductionAccounting.DataAccess.Configurations
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder
				.ToTable("category");

			builder
				.Property(c => c.Id)
				.HasColumnName("id");
			builder
				.Property(c => c.Name)
				.HasColumnName("name");
		}
	}
}
