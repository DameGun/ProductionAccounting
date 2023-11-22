using AutoMapper;
using ProductionAccounting.Application.Models.Box;
using ProductionAccounting.Core.Entities;

namespace ProductionAccounting.Application.Mappings
{
	public class BoxMappingProfile : Profile
	{
		public BoxMappingProfile()
		{
			CreateMap<Box, BoxDTO>();

			CreateMap<CreateBoxDTO, Box>();
		}
	}
}
