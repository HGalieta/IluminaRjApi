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
        public IEnumerable<ReadMunicipioDto> GetMunicipios()
        {
            return _mapper.Map<List<ReadMunicipioDto>>(_context.Municipios);
        }

        [HttpGet("{id}")]
        public IActionResult GetMunicipioById(int id)
        {
            var municipio = _context.Municipios
                .FirstOrDefault(m => m.Id == id);

            if (municipio == null) 
                return NotFound();

            var municipioDto = _mapper.Map<ReadMunicipioDto>(municipio);
            return Ok(municipioDto);
        }
    }
}
