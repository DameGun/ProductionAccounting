using AutoMapper;
using ProductionAccounting.Application.Models.Pallet;
using ProductionAccounting.Core.Entities;

namespace ProductionAccounting.Application.Mappings
{
	public class PalletMappingProfile : Profile
	{
		public PalletMappingProfile()
		{
			CreateMap<Pallet, PalletDTO>()
				.ForMember(dest => dest.ProductionApplication, opt => opt.MapFrom(src => src.ProductionApplication));

			CreateMap<CreatePalletDTO, Pallet>();

			CreateMap<UpdatePalletDTO, Pallet>();
		}
	}
}
