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

        /// <summary>
        /// Получить все события СНТ.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<SntEvent> sntEvents = Context.SntEvents.ToList();
            return Ok(sntEvents);
        }

        /// <summary>
        /// Получить событие по его идентификатору события, СНТ и пользователя.
        /// </summary>
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

        /// <summary>
        /// Добавить новое событие.
        /// </summary>
        [HttpPost]
        public IActionResult Add(SntEvent sntEvent)
        {
            Context.SntEvents.Add(sntEvent);
            Context.SaveChanges();
            return Ok(sntEvent);
        }

        /// <summary>
        /// Обновить существующее событие.
        /// </summary>
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

        /// <summary>
        /// Удалить событие.
        /// </summary>
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
