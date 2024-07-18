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

        /// <summary>
        /// Insere um município no banco de dados
        /// </summary>
        /// <param name="municipioDto">Objeto com os campos necessários para a criação de um município</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso a inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
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

        /// <summary>
        /// Retorna todos os municípios cadastrados no banco de dados
        /// </summary>
        /// <returns>IEnumerable</returns>
        /// <response code="200" >Retornando a listagem de todos os municipios inseridos no banco de dados</response>
        [HttpGet]
        public IEnumerable<ReadMunicipioDto> GetMunicipios()
        {
            return _mapper.Map<List<ReadMunicipioDto>>(_context.Municipios);
        }

        /// <summary>
        /// Retorna o município se este constar no banco de dados
        /// </summary>
        /// <param name="id">Número inteiro necessário para buscar o município no banco de dados</param>
        /// <returns>IEnumerable</returns>
        /// <response code="404">Caso o município com o id informado não exista no banco de dados</response>
        /// <response code="200" >Retornando o municipio que possui id correspondente no banco de dados</response>
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

        /// <summary>
        /// Atualiza todos os dados do municipio se este constar no banco de dados
        /// </summary>
        /// <param name="id">Número inteiro necessário para buscar o município no banco de dados</param>
        /// <param name="municipioDto">Objeto com os campos necessários para a atualização de todas as propriedades de um município</param>
        /// <returns>IEnumerable</returns>
        /// <response code="404">Caso o município com o id informado não exista no banco de dados</response>
        /// <response code="204" >Caso o municipio seja encontrado e os dados sejam atualizados no banco de dados</response>
        [HttpPut("{id}")]
        public IActionResult PutMunicipio(int id, UpdateMunicipioDto municipioDto)
        {
            var municipio = _context.Municipios
                .FirstOrDefault(m => m.Id == id);

            if (municipio == null)
                return NotFound();

            _mapper.Map(municipioDto, municipio);
            _context.SaveChanges();
            return NoContent();

        }

        /// <summary>
        /// Atualiza o dado informado do municipio se este constar no banco de dados
        /// </summary>
        /// <param name="id">Número inteiro necessário para buscar o município no banco de dados</param>
        /// <param name="patch">Documento informando os dados para a atualização de uma ou mais propriedades de um município</param>
        /// <returns>IEnumerable</returns>
        /// <response code="404">Caso o município com o id informado não exista no banco de dados</response>
        /// <response code="204" >Caso o municipio seja encontrado e o dado seja atualizado no banco de dados</response>
        [HttpPatch("{id}")]
        public IActionResult PatchMunicipio(int id, JsonPatchDocument<UpdateMunicipioDto> patch )
        {
            var municipio = _context.Municipios
                .FirstOrDefault(m => m.Id == id);

            if (municipio == null)
                return NotFound();

            var municipioUpdate = _mapper.Map<UpdateMunicipioDto>(municipio);

            patch.ApplyTo(municipioUpdate, ModelState);

            if(!TryValidateModel(municipioUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(municipioUpdate, municipio);
            _context.SaveChanges();

            return NoContent();

        }

        /// <summary>
        /// Remove o municipio do banco de dados se este constar no mesmo
        /// </summary>
        /// <param name="id">Número inteiro necessário para buscar o município no banco de dados</param>
        /// <returns>IEnumerable</returns>
        /// <response code="404">Caso o município com o id informado não exista no banco de dados</response>
        /// <response code="204" >Caso o municipio seja encontrado e removido do banco de dados</response>
        [HttpDelete("{id}")]
        public IActionResult DeleteMunicipio(int id)
        {
            var municipio = _context.Municipios
                .FirstOrDefault(m => m.Id == id);

            if (municipio == null)
                return NotFound();

            _context.Remove(municipio);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
