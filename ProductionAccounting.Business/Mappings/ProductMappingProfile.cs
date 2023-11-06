using AutoMapper;
using ProductionAccounting.Application.Models.Product;
using ProductionAccounting.Core.Aggregations;

namespace ProductionAccounting.Application.Mappings
{
    public class ProductMappingProfile : Profile
	{
		public ProductMappingProfile()
		{
			CreateMap<Product, ProductDTO>()
				.ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

			CreateMap<CreateProductDTO, Product>();
		}
	}
}
