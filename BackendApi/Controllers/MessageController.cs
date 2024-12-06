using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public CoutryhouseContext Context { get; }

        public MessageController(CoutryhouseContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Message> messages = Context.Messages.ToList();
            return Ok(messages);
        }

        // Получить сообщение по message_id и user_id
        [HttpGet("{messageId}/{userId}")]
        public IActionResult GetById(int messageId, int userId)
        {
            Message? message = Context.Messages
                .Where(x => x.MessageId == messageId && x.UserId == userId)
                .FirstOrDefault();
            if (message == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(message);
        }

        // Добавить новое сообщение
        [HttpPost]
        public IActionResult Add(Message message)
        {
            Context.Messages.Add(message);
            Context.SaveChanges();
            return Ok(message);
        }

        // Обновить сообщение
        [HttpPut]
        public IActionResult Update(Message message)
        {
            var existingMessage = Context.Messages
                .Where(x => x.MessageId == message.MessageId && x.UserId == message.UserId)
                .FirstOrDefault();
            if (existingMessage == null)
            {
                return BadRequest("Not Found");
            }

            // Обновление значений
            Context.Entry(existingMessage).CurrentValues.SetValues(message);
            Context.SaveChanges();
            return Ok(message);
        }

        // Удалить сообщение
        [HttpDelete("{messageId}/{userId}")]
        public IActionResult Delete(int messageId, int userId)
        {
            Message? message = Context.Messages
                .Where(x => x.MessageId == messageId && x.UserId == userId)
                .FirstOrDefault();
            if (message == null)
            {
                return BadRequest("Not Found");
            }
            Context.Messages.Remove(message);
            Context.SaveChanges();
            return Ok();
        }
    }
}
