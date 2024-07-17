using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace IluminaRJApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MunicipioController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostMunicipio()
        {
            throw new NotImplementedException();
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
