using AutoMapper;
using IluminaRJApi.Data.Dtos;
using IluminaRJApi.Models;

namespace IluminaRJApi.Data.Profiles
{
    public class MunicipioProfile : Profile
    {
        public MunicipioProfile()
        {
            CreateMap<CreateMunicipioDto, Municipio>();
            CreateMap<UpdateMunicipioDto, Municipio>();
            CreateMap<Municipio, UpdateMunicipioDto>();
            CreateMap<Municipio, ReadMunicipioDto>();
        }
    }
}
