using AutoMapper;
using ProductionAccounting.Application.Models;
using ProductionAccounting.Core.Aggregations;

namespace ProductionAccounting.Application.Mappings
{
	public class CategoryMappingProfile : Profile
	{
		public CategoryMappingProfile() {
			CreateMap<Category, CategoryDTO>();
		}
	}
}
