using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        public CoutryhouseContext Context { get; }

        public AnnouncementsController(CoutryhouseContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Announcement> announcements = Context.Announcements.ToList();
            return Ok(announcements);
        }

        // Получить объявление по announcements_id и user_id
        [HttpGet("{announcementsId}/{userId}")]
        public IActionResult GetById(int announcementsId, int userId)
        {
            Announcement? announcement = Context.Announcements
                .Where(x => x.AnnouncementsId == announcementsId && x.UserId == userId)
                .FirstOrDefault();
            if (announcement == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(announcement);
        }

        // Добавить новое объявление
        [HttpPost]
        public IActionResult Add(Announcement announcement)
        {
            Context.Announcements.Add(announcement);
            Context.SaveChanges();
            return Ok(announcement);
        }

        // Обновить объявление
        [HttpPut]
        public IActionResult Update(Announcement announcement)
        {
            var existingAnnouncement = Context.Announcements
                .Where(x => x.AnnouncementsId == announcement.AnnouncementsId && x.UserId == announcement.UserId)
                .FirstOrDefault();
            if (existingAnnouncement == null)
            {
                return BadRequest("Not Found");
            }

            // Обновление значений
            Context.Entry(existingAnnouncement).CurrentValues.SetValues(announcement);
            Context.SaveChanges();
            return Ok(announcement);
        }

        // Удалить объявление
        [HttpDelete("{announcementsId}/{userId}")]
        public IActionResult Delete(int announcementsId, int userId)
        {
            Announcement? announcement = Context.Announcements
                .Where(x => x.AnnouncementsId == announcementsId && x.UserId == userId)
                .FirstOrDefault();
            if (announcement == null)
            {
                return BadRequest("Not Found");
            }
            Context.Announcements.Remove(announcement);
            Context.SaveChanges();
            return Ok();
        }
    }
}
