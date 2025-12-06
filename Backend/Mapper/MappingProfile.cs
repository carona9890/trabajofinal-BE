using AutoMapper;
using TrabajoFinalBE.Dtos;
using TrabajoFinalBE.Models;

namespace TrabajoFinalBE.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ahorro, AhorroDto>().ReverseMap();
            CreateMap<CreateAhorroDto, Ahorro>();
            
            CreateMap<Transferencia, TransferenciaDto>().ReverseMap();
            CreateMap<CreateTransferenciaDto, Transferencia>();
        }
    }
}