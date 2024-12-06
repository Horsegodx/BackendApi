using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HarvestController : ControllerBase
    {
        public CoutryhouseContext Context { get; }

        public HarvestController(CoutryhouseContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Harvest> harvests = Context.Harvests.ToList();
            return Ok(harvests);
        }

        [HttpGet("{harvestId}/{plantId}")]
        public IActionResult GetById(int harvestId, int plantId)
        {
            Harvest? harvest = Context.Harvests
                .Where(x => x.HarvestId == harvestId && x.PlantId == plantId)
                .FirstOrDefault();
            if (harvest == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(harvest);
        }

        [HttpPost]
        public IActionResult Add(Harvest harvest)
        {
            Context.Harvests.Add(harvest);
            Context.SaveChanges();
            return Ok(harvest);
        }

        [HttpPut]
        public IActionResult Update(Harvest harvest)
        {
            var existingHarvest = Context.Harvests
                .Where(x => x.HarvestId == harvest.HarvestId && x.PlantId == harvest.PlantId)
                .FirstOrDefault();
            if (existingHarvest == null)
            {
                return BadRequest("Not Found");
            }

            // Обновление значений
            Context.Entry(existingHarvest).CurrentValues.SetValues(harvest);
            Context.SaveChanges();
            return Ok(harvest);
        }

        [HttpDelete("{harvestId}/{plantId}")]
        public IActionResult Delete(int harvestId, int plantId)
        {
            Harvest? harvest = Context.Harvests
                .Where(x => x.HarvestId == harvestId && x.PlantId == plantId)
                .FirstOrDefault();
            if (harvest == null)
            {
                return BadRequest("Not Found");
            }
            Context.Harvests.Remove(harvest);
            Context.SaveChanges();
            return Ok();
        }
    }
}
