using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantingController : ControllerBase
    {
        public CoutryhouseContext Context { get; }

        public PlantingController(CoutryhouseContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Planting> plantings = Context.Plantings.ToList();
            return Ok(plantings);
        }

        [HttpGet("{plantingId}/{plantId}")]
        public IActionResult GetById(int plantingId, int plantId)
        {
            Planting? planting = Context.Plantings
                .Where(x => x.PlantingId == plantingId && x.PlantId == plantId)
                .FirstOrDefault();
            if (planting == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(planting);
        }

        [HttpPost]
        public IActionResult Add(Planting planting)
        {
            Context.Plantings.Add(planting);
            Context.SaveChanges();
            return Ok(planting);
        }

        [HttpPut]
        public IActionResult Update(Planting planting)
        {
            var existingPlanting = Context.Plantings
                .Where(x => x.PlantingId == planting.PlantingId && x.PlantId == planting.PlantId)
                .FirstOrDefault();
            if (existingPlanting == null)
            {
                return BadRequest("Not Found");
            }

            // Обновление значений
            Context.Entry(existingPlanting).CurrentValues.SetValues(planting);
            Context.SaveChanges();
            return Ok(planting);
        }

        [HttpDelete("{plantingId}/{plantId}")]
        public IActionResult Delete(int plantingId, int plantId)
        {
            Planting? planting = Context.Plantings
                .Where(x => x.PlantingId == plantingId && x.PlantId == plantId)
                .FirstOrDefault();
            if (planting == null)
            {
                return BadRequest("Not Found");
            }
            Context.Plantings.Remove(planting);
            Context.SaveChanges();
            return Ok();
        }
    }
}
