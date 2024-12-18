using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SntController : ControllerBase
    {
        public CoutryhouseContext Context { get; }

        public SntController(CoutryhouseContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Получить все СНТ.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Snt> snts = Context.Snts.ToList();
            return Ok(snts);
        }

        /// <summary>
        /// Получить СНТ по его идентификатору и идентификатору пользователя.
        /// </summary>
        [HttpGet("{sntId}/{userId}")]
        public IActionResult GetById(int sntId, int userId)
        {
            Snt? snt = Context.Snts
                .Where(x => x.SntId == sntId && x.UserId == userId)
                .FirstOrDefault();
            if (snt == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(snt);
        }

        /// <summary>
        /// Добавить новое СНТ.
        /// </summary>
        [HttpPost]
        public IActionResult Add(Snt snt)
        {
            Context.Snts.Add(snt);
            Context.SaveChanges();
            return Ok(snt);
        }

        /// <summary>
        /// Обновить существующее СНТ.
        /// </summary>
        [HttpPut]
        public IActionResult Update(Snt snt)
        {
            var existingSnt = Context.Snts
                .Where(x => x.SntId == snt.SntId && x.UserId == snt.UserId)
                .FirstOrDefault();
            if (existingSnt == null)
            {
                return BadRequest("Not Found");
            }

            // Обновление значений
            Context.Entry(existingSnt).CurrentValues.SetValues(snt);
            Context.SaveChanges();
            return Ok(snt);
        }

        /// <summary>
        /// Удалить СНТ.
        /// </summary>
        [HttpDelete("{sntId}/{userId}")]
        public IActionResult Delete(int sntId, int userId)
        {
            Snt? snt = Context.Snts
                .Where(x => x.SntId == sntId && x.UserId == userId)
                .FirstOrDefault();
            if (snt == null)
            {
                return BadRequest("Not Found");
            }
            Context.Snts.Remove(snt);
            Context.SaveChanges();
            return Ok();
        }
    }
}