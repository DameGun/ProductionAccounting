using AutoMapper;
using ProductionAccounting.Application.Models.ProductUnit;
using ProductionAccounting.Core.Entities;

namespace ProductionAccounting.Application.Mappings
{
	public class ProductUnitMappingProfile : Profile
	{
		public ProductUnitMappingProfile()
		{
			CreateMap<ProductUnit, ProductUnitDTO>()
				.ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product));

			CreateMap<CreateProductUnitDTO, ProductUnit>();
		}
	}
}
