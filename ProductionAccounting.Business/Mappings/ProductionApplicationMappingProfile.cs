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
				.ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
				.ForMember(dest => dest.BoxesInPalletMax, opt => opt.MapFrom(src => src.BoxesInPallet))
				.ForMember(dest => dest.PackagesInBoxMax, opt => opt.MapFrom(src => src.BoxesInPallet));

			CreateMap<ProductionApplicationDTO, ProductionApplication>()
				.ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
				.ForMember(dest => dest.BoxesInPallet, opt => opt.MapFrom(src => src.BoxesInPalletMax))
				.ForMember(dest => dest.PackagesInBox, opt => opt.MapFrom(src => src.PackagesInBoxMax));

			CreateMap<CreateProductionApplicationDTO, ProductionApplication>();

			CreateMap<UpdateProductionApplicationDTO, ProductionApplication>()
				.ForMember(dest => dest.ProdDate, opt => opt.MapFrom(src => src.ProdDate.ToUniversalTime()))
				.ForMember(dest => dest.ExpDate, opt => opt.MapFrom(src => src.ExpDate.ToUniversalTime()));

			CreateMap<ServerUpdateApplicationDTO, ProductionApplication>();
		}
	}
}
