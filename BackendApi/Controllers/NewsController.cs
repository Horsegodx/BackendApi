using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        public CoutryhouseContext Context { get; }

        public NewsController(CoutryhouseContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<News> newsList = Context.News.ToList();
            return Ok(newsList);
        }

        // Получить новость по ID и user_id
        [HttpGet("{newsId}/{userId}")]
        public IActionResult GetById(int newsId, int userId)
        {
            News? news = Context.News
                .Where(x => x.NewsId == newsId && x.UserId == userId)
                .FirstOrDefault();
            if (news == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(news);
        }

        // Добавить новость
        [HttpPost]
        public IActionResult Add(News news)
        {
            Context.News.Add(news);
            Context.SaveChanges();
            return Ok(news);
        }

        // Обновить новость
        [HttpPut]
        public IActionResult Update(News news)
        {
            var existingNews = Context.News
                .Where(x => x.NewsId == news.NewsId && x.UserId == news.UserId)
                .FirstOrDefault();
            if (existingNews == null)
            {
                return BadRequest("Not Found");
            }

            // Обновление значений
            Context.Entry(existingNews).CurrentValues.SetValues(news);
            Context.SaveChanges();
            return Ok(news);
        }

        // Удалить новость
        [HttpDelete("{newsId}/{userId}")]
        public IActionResult Delete(int newsId, int userId)
        {
            News? news = Context.News
                .Where(x => x.NewsId == newsId && x.UserId == userId)
                .FirstOrDefault();
            if (news == null)
            {
                return BadRequest("Not Found");
            }
            Context.News.Remove(news);
            Context.SaveChanges();
            return Ok();
        }
    }
}
