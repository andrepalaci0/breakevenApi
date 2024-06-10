using breakevenApi.Queries;
using Microsoft.AspNetCore.Mvc;

namespace breakevenApi.Controllers
{
    [Route("/medic")]
    public class MedicController : Controller
    {
        private readonly MedicQuery _queries;

        public MedicController(MedicQuery queries)
        {
            _queries = queries;
        }

        [HttpGet]
        [Route("/get/{id}")]
        public IActionResult getMedicById(long id)
        {
            // Call the appropriate method from _queries to get medic by id
            var medic = _queries.findMedicByCrm(id);

            if (medic == null )
            {
                return NotFound(); // Return 404 Not Found if medic is not found
            }

            return Ok(medic); // Return 200 OK with the medic data
        }
    }
}
