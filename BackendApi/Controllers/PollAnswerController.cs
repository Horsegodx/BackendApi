using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollAnswerController : ControllerBase
    {
        public CoutryhouseContext Context { get; }

        public PollAnswerController(CoutryhouseContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<PollAnswer> answers = Context.PollAnswers.ToList();
            return Ok(answers);
        }

        [HttpGet("{answerId}/{userId}/{optionId}/{pollId}")]
        public IActionResult GetById(int answerId, int userId, int optionId, int pollId)
        {
            PollAnswer? answer = Context.PollAnswers
                .Where(x => x.AnswerId == answerId && x.UserId == userId && x.OptionId == optionId && x.PollId == pollId)
                .FirstOrDefault();
            if (answer == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(answer);
        }

        [HttpPost]
        public IActionResult Add(PollAnswer answer)
        {
            Context.PollAnswers.Add(answer);
            Context.SaveChanges();
            return Ok(answer);
        }

        [HttpPut]
        public IActionResult Update(PollAnswer answer)
        {
            var existingAnswer = Context.PollAnswers
                .Where(x => x.AnswerId == answer.AnswerId && x.UserId == answer.UserId && x.OptionId == answer.OptionId && x.PollId == answer.PollId)
                .FirstOrDefault();
            if (existingAnswer == null)
            {
                return BadRequest("Not Found");
            }

            // Обновление значений
            Context.Entry(existingAnswer).CurrentValues.SetValues(answer);
            Context.SaveChanges();
            return Ok(answer);
        }

        [HttpDelete("{answerId}/{userId}/{optionId}/{pollId}")]
        public IActionResult Delete(int answerId, int userId, int optionId, int pollId)
        {
            PollAnswer? answer = Context.PollAnswers
                .Where(x => x.AnswerId == answerId && x.UserId == userId && x.OptionId == optionId && x.PollId == pollId)
                .FirstOrDefault();
            if (answer == null)
            {
                return BadRequest("Not Found");
            }
            Context.PollAnswers.Remove(answer);
            Context.SaveChanges();
            return Ok();
        }

    }
}
