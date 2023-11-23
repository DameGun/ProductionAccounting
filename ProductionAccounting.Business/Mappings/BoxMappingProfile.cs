using AutoMapper;
using ProductionAccounting.Application.Models.Box;
using ProductionAccounting.Core.Entities;

namespace ProductionAccounting.Application.Mappings
{
	public class BoxMappingProfile : Profile
	{
		public BoxMappingProfile()
		{
			CreateMap<Box, BoxDTO>()
				.ForMember(dest => dest.ProductionApplication, opt => opt.MapFrom(src => src.ProductionApplication));

			CreateMap<CreateBoxDTO, Box>();

			CreateMap<UpdateBoxDTO, Box>();
		}
	}
}
