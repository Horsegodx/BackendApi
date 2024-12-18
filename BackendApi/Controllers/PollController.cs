using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollController : ControllerBase
    {
        public CoutryhouseContext Context { get; }

        public PollController(CoutryhouseContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Получить все опросы.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Poll> polls = Context.Polls.ToList();
            return Ok(polls);
        }

        /// <summary>
        /// Получить опрос по его идентификатору.
        /// </summary>
        [HttpGet("{pollId}")]
        public IActionResult GetById(int pollId)
        {
            Poll? poll = Context.Polls
                .Where(x => x.PollId == pollId)
                .FirstOrDefault();
            if (poll == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(poll);
        }

        /// <summary>
        /// Добавить новый опрос.
        /// </summary>
        [HttpPost]
        public IActionResult Add(Poll poll)
        {
            Context.Polls.Add(poll);
            Context.SaveChanges();
            return Ok(poll);
        }

        /// <summary>
        /// Обновить существующий опрос.
        /// </summary>
        [HttpPut]
        public IActionResult Update(Poll poll)
        {
            var existingPoll = Context.Polls
                .Where(x => x.PollId == poll.PollId)
                .FirstOrDefault();
            if (existingPoll == null)
            {
                return BadRequest("Not Found");
            }

            // Обновление значений
            Context.Entry(existingPoll).CurrentValues.SetValues(poll);
            Context.SaveChanges();
            return Ok(poll);
        }

        /// <summary>
        /// Удалить опрос.
        /// </summary>
        [HttpDelete("{pollId}")]
        public IActionResult Delete(int pollId)
        {
            Poll? poll = Context.Polls
                .Where(x => x.PollId == pollId)
                .FirstOrDefault();
            if (poll == null)
            {
                return BadRequest("Not Found");
            }
            Context.Polls.Remove(poll);
            Context.SaveChanges();
            return Ok();
        }
    }
}
