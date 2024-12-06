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

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Snt> snts = Context.Snts.ToList();
            return Ok(snts);
        }

        // Получить СНТ по snt_id и user_id
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

        // Добавить новое СНТ
        [HttpPost]
        public IActionResult Add(Snt snt)
        {
            Context.Snts.Add(snt);
            Context.SaveChanges();
            return Ok(snt);
        }

        // Обновить СНТ
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

        // Удалить СНТ
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
