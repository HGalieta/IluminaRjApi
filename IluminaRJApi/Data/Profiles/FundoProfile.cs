using AutoMapper;
using IluminaRJApi.Data.Dtos;
using IluminaRJApi.Models;

namespace IluminaRJApi.Data.Profiles
{
    public class FundoProfile : Profile
    {
        public FundoProfile()
        {
            CreateMap<CreateFundoDto, Fundo>();
            CreateMap<UpdateFundoDto, Fundo>();
            CreateMap<Fundo, UpdateFundoDto>();
            CreateMap<Fundo, ReadFundoDto>();
        }
    }
}
