using AutoMapper;
using IluminaRJApi.Data.Dtos;
using IluminaRJApi.Data;
using IluminaRJApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace IluminaRJApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {
        private DataContext _context;
        private IMapper _mapper;

        public EmpresaController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Insere uma empresa no banco de dados
        /// </summary>
        /// <param name="empresaDto">Objeto com os campos necessários para a criação de uma empresa</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso a inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostEmpresa(CreateEmpresaDto empresaDto)
        {
            Empresa empresa = _mapper.Map<Empresa>(empresaDto);
            _context.Empresas.Add(empresa);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(GetEmpresaById),
                new { id = empresa.Id },
                empresa);
        }

        /// <summary>
        /// Retorna todas as empresas cadastradas no banco de dados
        /// </summary>
        /// <returns>IEnumerable</returns>
        /// <response code="200" >Retornando a listagem de todas as empresas inseridas no banco de dados</response>
        [HttpGet]
        public IEnumerable<ReadEmpresaDto> GetEmpresas()
        {
            return _mapper.Map<List<ReadEmpresaDto>>(_context.Empresas);
        }

        /// <summary>
        /// Retorna a empresa se esta constar no banco de dados
        /// </summary>
        /// <param name="id">Número inteiro necessário para buscar a empresa no banco de dados</param>
        /// <returns>IEnumerable</returns>
        /// <response code="404">Caso a empresa com o id informado não exista no banco de dados</response>
        /// <response code="200" >Retornando a empresa que possui id correspondente no banco de dados</response>
        [HttpGet("{id}")]
        public IActionResult GetEmpresaById(int id)
        {
            var empresa = _context.Empresas
                .FirstOrDefault(e => e.Id == id);

            if (empresa == null)
                return NotFound();

            var empresaDto = _mapper.Map<ReadEmpresaDto>(empresa);
            return Ok(empresaDto);
        }

        /// <summary>
        /// Atualiza todos os dados da empresa se este constar no banco de dados
        /// </summary>
        /// <param name="id">Número inteiro necessário para buscar a empresa no banco de dados</param>
        /// <param name="empresaDto">Objeto com os campos necessários para a atualização de todas as propriedades de uma empresa</param>
        /// <returns>IEnumerable</returns>
        /// <response code="404">Caso a empresa com o id informado não exista no banco de dados</response>
        /// <response code="204" >Caso a empresa seja encontrada e os dados sejam atualizados no banco de dados</response>
        [HttpPut("{id}")]
        public IActionResult PutEmpresa(int id, UpdateEmpresaDto empresaDto)
        {
            var empresa = _context.Empresas
                .FirstOrDefault(e => e.Id == id);

            if (empresa == null)
                return NotFound();

            _mapper.Map(empresaDto, empresa);
            _context.SaveChanges();
            return NoContent();

        }

        /// <summary>
        /// Atualiza o dado informado da empresa se esta constar no banco de dados
        /// </summary>
        /// <param name="id">Número inteiro necessário para buscar a empresa no banco de dados</param>
        /// <param name="patch">Documento informando os dados para a atualização de uma ou mais propriedades de uma empresa</param>
        /// <returns>IEnumerable</returns>
        /// <response code="404">Caso a empresa com o id informado não exista no banco de dados</response>
        /// <response code="204" >Caso a empresa seja encontrada e o dado seja atualizado no banco de dados</response>
        [HttpPatch("{id}")]
        public IActionResult PatchEmpresa(int id, JsonPatchDocument<UpdateEmpresaDto> patch)
        {
            var empresa = _context.Empresas
                .FirstOrDefault(e => e.Id == id);

            if (empresa == null)
                return NotFound();

            var empresaUpdate = _mapper.Map<UpdateEmpresaDto>(empresa);

            patch.ApplyTo(empresaUpdate, ModelState);

            if (!TryValidateModel(empresaUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(empresaUpdate, empresa);
            _context.SaveChanges();

            return NoContent();

        }

        /// <summary>
        /// Remove a empresa do banco de dados se esta constar no mesmo
        /// </summary>
        /// <param name="id">Número inteiro necessário para buscar a empresa no banco de dados</param>
        /// <returns>IEnumerable</returns>
        /// <response code="404">Caso a empresa com o id informado não exista no banco de dados</response>
        /// <response code="204" >Caso a empresa seja encontrada e removida do banco de dados</response>
        [HttpDelete("{id}")]
        public IActionResult DeleteEmpresa(int id)
        {
            var empresa = _context.Empresas
                .FirstOrDefault(e => e.Id == id);

            if (empresa == null)
                return NotFound();

            _context.Remove(empresa);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
