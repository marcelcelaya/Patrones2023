using Business.Contracts;
using Domain;
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
        public async Task<ActionResult> Add(Encuesta encuesta)
        {
            int encuestaId = _encuestaService.Add(encuesta);
            return Ok(encuestaId);
        }


        [HttpGet("{id}")]

        public async Task<ActionResult> Get([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();
            Encuesta encuesta = _encuestaService.Get(id);
            if (encuesta == null) return NotFound();
            if (encuesta.Id <= 0) return NotFound();
            return Ok(encuesta);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();
            bool result = _encuestaService.Delete(id);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("{id}/users")]
        public async Task<ActionResult> GetUsersFromSurvey([FromRoute] int surveyId)
        {
            if (surveyId <= 0) return BadRequest();
            return Ok(_encuestaService.GetUsersFromSurvey(surveyId));
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Encuesta encuesta)
        {
            if (encuesta == null) return BadRequest();
            if (encuesta.Id <= 0) return BadRequest();
            return Ok(_encuestaService.Update(encuesta));
        }

        [HttpPost("{idSurvey}/User/{idUser}")]
        public async Task<ActionResult> RelateSurveyWithUser([FromRoute] int idSurvey, [FromRoute] int idUser)
        {
            if (idSurvey <= 0) return BadRequest();
            if (idUser <= 0) return BadRequest();
            return Ok(_encuestaService.RelateSurveyWithUser(idSurvey, idUser));
        }
    }
}
