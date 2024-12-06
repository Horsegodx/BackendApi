using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SntEventController : ControllerBase
    {
        public CoutryhouseContext Context { get; }

        public SntEventController(CoutryhouseContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<SntEvent> sntEvents = Context.SntEvents.ToList();
            return Ok(sntEvents);
        }

        // Получить событие по event_id, snt_id и user_id
        [HttpGet("{eventId}/{sntId}/{userId}")]
        public IActionResult GetById(int eventId, int sntId, int userId)
        {
            SntEvent? sntEvent = Context.SntEvents
                .Where(x => x.EventId == eventId && x.SntId == sntId && x.UserId == userId)
                .FirstOrDefault();
            if (sntEvent == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(sntEvent);
        }

        // Добавить новое событие
        [HttpPost]
        public IActionResult Add(SntEvent sntEvent)
        {
            Context.SntEvents.Add(sntEvent);
            Context.SaveChanges();
            return Ok(sntEvent);
        }

        // Обновить событие
        [HttpPut]
        public IActionResult Update(SntEvent sntEvent)
        {
            var existingSntEvent = Context.SntEvents
                .Where(x => x.EventId == sntEvent.EventId && x.SntId == sntEvent.SntId && x.UserId == sntEvent.UserId)
                .FirstOrDefault();
            if (existingSntEvent == null)
            {
                return BadRequest("Not Found");
            }

            // Обновление значений
            Context.Entry(existingSntEvent).CurrentValues.SetValues(sntEvent);
            Context.SaveChanges();
            return Ok(sntEvent);
        }

        // Удалить событие
        [HttpDelete("{eventId}/{sntId}/{userId}")]
        public IActionResult Delete(int eventId, int sntId, int userId)
        {
            SntEvent? sntEvent = Context.SntEvents
                .Where(x => x.EventId == eventId && x.SntId == sntId && x.UserId == userId)
                .FirstOrDefault();
            if (sntEvent == null)
            {
                return BadRequest("Not Found");
            }
            Context.SntEvents.Remove(sntEvent);
            Context.SaveChanges();
            return Ok();
        }
    }
}
