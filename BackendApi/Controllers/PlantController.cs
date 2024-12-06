using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        public CoutryhouseContext Context { get; }

        public PlantController(CoutryhouseContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Plant> plants = Context.Plants.ToList();
            return Ok(plants);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Plant? plant = Context.Plants.Where(x => x.PlantId == id).FirstOrDefault();
            if (plant == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(plant);
        }

        [HttpPost]
        public IActionResult Add(Plant plant)
        {
            Context.Plants.Add(plant);
            Context.SaveChanges();
            return Ok(plant);
        }

        [HttpPut]
        public IActionResult Update(Plant plant)
        {
            Context.Plants.Update(plant);
            Context.SaveChanges();
            return Ok(plant);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Plant? plant = Context.Plants.Where(x => x.PlantId == id).FirstOrDefault();
            if (plant == null)
            {
                return BadRequest("Not Found");
            }
            Context.Plants.Remove(plant);
            Context.SaveChanges();
            return Ok();
        }

    }
}
