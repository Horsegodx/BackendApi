using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FertilizationController : ControllerBase
    {
        public CoutryhouseContext Context { get; }

        public FertilizationController(CoutryhouseContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Fertilization> fertilizations = Context.Fertilizations.ToList();
            return Ok(fertilizations);
        }

        [HttpGet("{fertilizationId}/{plantId}")]
        public IActionResult GetById(int fertilizationId, int plantId)
        {
            Fertilization? fertilization = Context.Fertilizations
                .Where(x => x.FertilizationId == fertilizationId && x.PlantId == plantId)
                .FirstOrDefault();
            if (fertilization == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(fertilization);
        }

        [HttpPost]
        public IActionResult Add(Fertilization fertilization)
        {
            Context.Fertilizations.Add(fertilization);
            Context.SaveChanges();
            return Ok(fertilization);
        }

        [HttpPut]
        public IActionResult Update(Fertilization fertilization)
        {
            var existingFertilization = Context.Fertilizations
                .Where(x => x.FertilizationId == fertilization.FertilizationId && x.PlantId == fertilization.PlantId)
                .FirstOrDefault();
            if (existingFertilization == null)
            {
                return BadRequest("Not Found");
            }

            // Обновление значений
            Context.Entry(existingFertilization).CurrentValues.SetValues(fertilization);
            Context.SaveChanges();
            return Ok(fertilization);
        }

        [HttpDelete("{fertilizationId}/{plantId}")]
        public IActionResult Delete(int fertilizationId, int plantId)
        {
            Fertilization? fertilization = Context.Fertilizations
                .Where(x => x.FertilizationId == fertilizationId && x.PlantId == plantId)
                .FirstOrDefault();
            if (fertilization == null)
            {
                return BadRequest("Not Found");
            }
            Context.Fertilizations.Remove(fertilization);
            Context.SaveChanges();
            return Ok();
        }
    }
}
