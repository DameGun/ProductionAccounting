using AutoMapper;
using ProductionAccounting.Application.Models.ProductionApplication;
using ProductionAccounting.Core.Entities;

namespace ProductionAccounting.Application.Mappings
{
    public class ProductionApplicationMappingProfile : Profile
	{
		public ProductionApplicationMappingProfile()
		{
			CreateMap<ProductionApplication, ProductionApplicationDTO>()
				.ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product));

			CreateMap<CreateProductionApplicationDTO, ProductionApplication>();
		}
	}
}
