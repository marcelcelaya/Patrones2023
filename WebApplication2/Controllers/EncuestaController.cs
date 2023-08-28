using Business.Contracts;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncuestaController : ControllerBase
    {
        private readonly IEncuestaService _encuestaService;

        public EncuestaController(IEncuestaService encuestaService)
        {
            _encuestaService = encuestaService;
        }

        [HttpPost]
        public async Task<ActionResult> Add(Encuesta encuesta){
            int encuestaId =  _encuestaService.Add(encuesta);
            return Ok(encuestaId);
        }
    }
}
