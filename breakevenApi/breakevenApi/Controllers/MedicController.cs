
using breakevenApi.Domain.Entities.Medic;
using Microsoft.AspNetCore.Mvc;

namespace breakevenApi.Controllers
{
    [Route("/medic")]
    public class MedicController : Controller
    {
        private readonly IMedicRepository _medicRepository;

        public MedicController(IMedicRepository medicRepository)
        {
            _medicRepository = medicRepository;
        }

        [HttpGet]
        [Route("/get/{id}")]
        public IActionResult getMedicById(long id)
        {
            // Call the appropriate method from _queries to get medic by id
            var medic = _medicRepository.GetByCrm(id);
            if (medic == null )
            {
                return NotFound(); // Return 404 Not Found if medic is not found
            }

            return Ok(medic); // Return 200 OK with the medic data
        }
    }
}
