using AutoMapper;
using ProductionAccounting.Application.Models.Pallet;
using ProductionAccounting.Core.Entities;

namespace ProductionAccounting.Application.Mappings
{
	public class PalletMappingProfile : Profile
	{
		public PalletMappingProfile()
		{
			CreateMap<Pallet, PalletDTO>();

			CreateMap<CreatePalletDTO, Pallet>();
		}
	}
}
