using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        public CoutryhouseContext Context { get; }

        public AnimalsController(CoutryhouseContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Animal> animals = Context.Animals.ToList();
            return Ok(animals);
        }

        // Получить животное по animals_id
        [HttpGet("{animalsId}")]
        public IActionResult GetById(int animalsId)
        {
            Animal? animal = Context.Animals
                .Where(x => x.AnimalsId == animalsId)
                .FirstOrDefault();
            if (animal == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(animal);
        }

        // Добавить новое животное
        [HttpPost]
        public IActionResult Add(Animal animal)
        {
            Context.Animals.Add(animal);
            Context.SaveChanges();
            return Ok(animal);
        }

        // Обновить информацию о животном
        [HttpPut]
        public IActionResult Update(Animal animal)
        {
            var existingAnimal = Context.Animals
                .Where(x => x.AnimalsId == animal.AnimalsId)
                .FirstOrDefault();
            if (existingAnimal == null)
            {
                return BadRequest("Not Found");
            }

            // Обновление значений
            Context.Entry(existingAnimal).CurrentValues.SetValues(animal);
            Context.SaveChanges();
            return Ok(animal);
        }

        // Удалить животное
        [HttpDelete("{animalsId}")]
        public IActionResult Delete(int animalsId)
        {
            Animal? animal = Context.Animals
                .Where(x => x.AnimalsId == animalsId)
                .FirstOrDefault();
            if (animal == null)
            {
                return BadRequest("Not Found");
            }
            Context.Animals.Remove(animal);
            Context.SaveChanges();
            return Ok();
        }
    }
}
