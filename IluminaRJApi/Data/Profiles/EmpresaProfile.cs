using AutoMapper;
using IluminaRJApi.Data.Dtos;
using IluminaRJApi.Models;

namespace IluminaRJApi.Data.Profiles
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<CreateEmpresaDto, Empresa>();
            CreateMap<UpdateEmpresaDto, Empresa>();
            CreateMap<Empresa, UpdateEmpresaDto>();
            CreateMap<Empresa, ReadEmpresaDto>();
        }
    }
}
