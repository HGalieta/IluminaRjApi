using AutoMapper;
using IluminaRJApi.Data;
using IluminaRJApi.Data.Dtos;
using IluminaRJApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace IluminaRJApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MunicipioController : ControllerBase
    {
        private DataContext _context;
        private IMapper _mapper;

        public MunicipioController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult PostMunicipio(CreateMunicipioDto municipioDto)
        {
            Municipio municipio = _mapper.Map<Municipio>(municipioDto);
            _context.Municipios.Add(municipio);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(GetMunicipioById),
                new { id = municipio.Id },
                municipio);
        }

        [HttpGet]
        public IActionResult GetMunicipios()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public IActionResult GetMunicipioById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
