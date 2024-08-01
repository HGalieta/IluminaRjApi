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
    public class FundoController : ControllerBase
    {
        private DataContext _context;
        private IMapper _mapper;

        public FundoController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Insere umm fundo no banco de dados
        /// </summary>
        /// <param name="fundoDto">Objeto com os campos necessários para a criação de um fundo</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso a inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostFundo(CreateFundoDto fundoDto)
        {
            Fundo fundo = _mapper.Map<Fundo>(fundoDto);
            _context.Fundos.Add(fundo);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(GetFundoById),
                new { id = fundo.Id },
                fundo);
        }

        /// <summary>
        /// Retorna todos os fundos cadastrados no banco de dados
        /// </summary>
        /// <returns>IEnumerable</returns>
        /// <response code="200" >Retornando a listagem de todos os fundos inseridos no banco de dados</response>
        [HttpGet]
        public IEnumerable<ReadFundoDto> GetFundo()
        {
            return _mapper.Map<List<ReadFundoDto>>(_context.Fundos);
        }

        /// <summary>
        /// Retorna o fundo se este constar no banco de dados
        /// </summary>
        /// <param name="id">Número inteiro necessário para buscar o fundo no banco de dados</param>
        /// <returns>IEnumerable</returns>
        /// <response code="404">Caso o fundo com o id informado não exista no banco de dados</response>
        /// <response code="200" >Retornandoo fundo que possui id correspondente no banco de dados</response>
        [HttpGet("{id}")]
        public IActionResult GetFundoById(int id)
        {
            var fundo = _context.Fundos
                .FirstOrDefault(f => f.Id == id);

            if (fundo == null)
                return NotFound();

            var fundoDto = _mapper.Map<ReadFundoDto>(fundo);
            return Ok(fundoDto);
        }

        /// <summary>
        /// Atualiza todos os dados do fundo se este constar no banco de dados
        /// </summary>
        /// <param name="id">Número inteiro necessário para buscar o fundo no banco de dados</param>
        /// <param name="fundoDto">Objeto com os campos necessários para a atualização de todas as propriedades de um fundo</param>
        /// <returns>IEnumerable</returns>
        /// <response code="404">Caso o fundo com o id informado não exista no banco de dados</response>
        /// <response code="204" >Caso o fundo seja encontrado e os dados sejam atualizados no banco de dados</response>
        [HttpPut("{id}")]
        public IActionResult PutFundo(int id, UpdateFundoDto fundoDto)
        {
            var fundo = _context.Fundos
                .FirstOrDefault(f => f.Id == id);

            if (fundo == null)
                return NotFound();

            _mapper.Map(fundoDto, fundo);
            _context.SaveChanges();
            return NoContent();

        }

        /// <summary>
        /// Atualiza o dado informado do fundo se este constar no banco de dados
        /// </summary>
        /// <param name="id">Número inteiro necessário para buscar o fundo no banco de dados</param>
        /// <param name="patch">Documento informando os dados para a atualização de uma ou mais propriedades de um fundo</param>
        /// <returns>IEnumerable</returns>
        /// <response code="404">Caso o fundo com o id informado não exista no banco de dados</response>
        /// <response code="204" >Caso o fundo seja encontrado e o dado seja atualizado no banco de dados</response>
        [HttpPatch("{id}")]
        public IActionResult PatchFundo(int id, JsonPatchDocument<UpdateFundoDto> patch)
        {
            var fundo = _context.Fundos
                .FirstOrDefault(f => f.Id == id);

            if (fundo == null)
                return NotFound();

            var fundoUpdate = _mapper.Map<UpdateFundoDto>(fundo);

            patch.ApplyTo(fundoUpdate, ModelState);

            if (!TryValidateModel(fundoUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(fundoUpdate, fundo);
            _context.SaveChanges();

            return NoContent();

        }

        /// <summary>
        /// Remove o fundo do banco de dados se esta constar no mesmo
        /// </summary>
        /// <param name="id">Número inteiro necessário para buscar o fundo no banco de dados</param>
        /// <returns>IEnumerable</returns>
        /// <response code="404">Caso o fundo com o id informado não exista no banco de dados</response>
        /// <response code="204" >Caso o fundo seja encontrado e removida do banco de dados</response>
        [HttpDelete("{id}")]
        public IActionResult DeleteFundo(int id)
        {
            var fundo = _context.Fundos
                .FirstOrDefault(f => f.Id == id);

            if (fundo == null)
                return NotFound();

            _context.Remove(fundo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
