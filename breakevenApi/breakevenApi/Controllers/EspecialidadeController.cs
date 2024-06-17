using breakevenApi.Domain.Entities.Especialidade;
using Microsoft.AspNetCore.Mvc;

namespace breakevenApi.Controllers
{
    [Route("/especialidade")]
    public class EspecialidadeController : Controller
    {

        private readonly IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadeController(IEspecialidadeRepository especialidadeRepository)
        {
            _especialidadeRepository = especialidadeRepository;
        }



        [HttpGet]
        [Route("/{id}")]
        public IActionResult GetEspecialidadeById(long id)
        {
            return Ok(_especialidadeRepository.GetByCodigo(id));
        }

        [HttpPut]
        public IActionResult CreateEspecialidade([FromBody] Especialidade especialidade)
        {
            try{
                _especialidadeRepository.Create(especialidade);
                return Ok();
            }catch(Exception e)
            {
                return BadRequest();
            }
        }
    }
}
