using AutoMapper;
using ProductionAccounting.Application.Models.Category;
using ProductionAccounting.Core.Aggregations;

namespace ProductionAccounting.Application.Mappings
{
    public class CategoryMappingProfile : Profile
	{
		public CategoryMappingProfile() {
			CreateMap<Category, CategoryDTO>();

			CreateMap<CreateCategoryDTO, Category>();

			CreateMap<UpdateCategoryDTO, Category>();
		}
	}
}
