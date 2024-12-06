using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedingScheduleController : ControllerBase
    {
        public CoutryhouseContext Context { get; }

        public FeedingScheduleController(CoutryhouseContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<FeedingSchedule> feedingSchedules = Context.FeedingSchedules.ToList();
            return Ok(feedingSchedules);
        }

        // Получить расписание кормления по feeding_id и animals_id
        [HttpGet("{feedingId}/{animalsId}")]
        public IActionResult GetById(int feedingId, int animalsId)
        {
            FeedingSchedule? feedingSchedule = Context.FeedingSchedules
                .Where(x => x.FeedingId == feedingId && x.AnimalsId == animalsId)
                .FirstOrDefault();
            if (feedingSchedule == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(feedingSchedule);
        }

        // Добавить новое расписание кормления
        [HttpPost]
        public IActionResult Add(FeedingSchedule feedingSchedule)
        {
            Context.FeedingSchedules.Add(feedingSchedule);
            Context.SaveChanges();
            return Ok(feedingSchedule);
        }

        // Обновить расписание кормления
        [HttpPut]
        public IActionResult Update(FeedingSchedule feedingSchedule)
        {
            var existingFeedingSchedule = Context.FeedingSchedules
                .Where(x => x.FeedingId == feedingSchedule.FeedingId && x.AnimalsId == feedingSchedule.AnimalsId)
                .FirstOrDefault();
            if (existingFeedingSchedule == null)
            {
                return BadRequest("Not Found");
            }

            // Обновление значений
            Context.Entry(existingFeedingSchedule).CurrentValues.SetValues(feedingSchedule);
            Context.SaveChanges();
            return Ok(feedingSchedule);
        }

        // Удалить расписание кормления
        [HttpDelete("{feedingId}/{animalsId}")]
        public IActionResult Delete(int feedingId, int animalsId)
        {
            FeedingSchedule? feedingSchedule = Context.FeedingSchedules
                .Where(x => x.FeedingId == feedingId && x.AnimalsId == animalsId)
                .FirstOrDefault();
            if (feedingSchedule == null)
            {
                return BadRequest("Not Found");
            }
            Context.FeedingSchedules.Remove(feedingSchedule);
            Context.SaveChanges();
            return Ok();
        }
    }
}
