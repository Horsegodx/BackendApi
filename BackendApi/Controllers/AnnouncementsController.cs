using BackendApi.Contracts.Announcement;
using Domain.Models;
using Mapster;
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
        /// <summary>
        /// Получить список всех объявлений.
        /// </summary>
        /// <returns>Список объявлений в формате GetAnnouncementsResponse.</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var announcements = Context.Announcements.ToList();
            var response = announcements.Adapt<List<GetAnnouncementsResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получить объявление по идентификатору и идентификатору пользователя.
        /// </summary>
        /// <param name="announcementsId">Идентификатор объявления.</param>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Объявление в формате GetAnnouncementsResponse или ошибка 400, если не найдено.</returns>
        [HttpGet("{announcementsId}/{userId}")]
        public IActionResult GetById(int announcementsId, int userId)
        {
            var announcement = Context.Announcements
                .Where(x => x.AnnouncementsId == announcementsId && x.UserId == userId)
                .FirstOrDefault();

            if (announcement == null)
            {
                return BadRequest("Not Found");
            }

            var response = announcement.Adapt<GetAnnouncementsResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Добавить новое объявление.
        /// </summary>
        /// <param name="request">Данные для создания объявления в формате CreateAnnouncementsRequest.</param>
        /// <returns>Созданное объявление в формате GetAnnouncementsResponse.</returns>
        [HttpPost]
        public IActionResult Add(CreateAnnouncementsRequest request)
        {
            var announcement = request.Adapt<Announcement>();
            Context.Announcements.Add(announcement);
            Context.SaveChanges();
            return Ok(announcement.Adapt<GetAnnouncementsResponse>());
        }

        /// <summary>
        /// Обновить существующее объявление.
        /// </summary>
        /// <param name="request">Данные для обновления объявления в формате CreateAnnouncementsRequest.</param>
        /// <param name="announcementsId">Идентификатор объявления.</param>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Обновленное объявление в формате GetAnnouncementsResponse или ошибка 400, если не найдено.</returns>
        [HttpPut]
        public IActionResult Update(CreateAnnouncementsRequest request, int announcementsId, int userId)
        {
            var existingAnnouncement = Context.Announcements
                .Where(x => x.AnnouncementsId == announcementsId && x.UserId == userId)
                .FirstOrDefault();

            if (existingAnnouncement == null)
            {
                return BadRequest("Not Found");
            }

            request.Adapt(existingAnnouncement);
            Context.SaveChanges();
            return Ok(existingAnnouncement.Adapt<GetAnnouncementsResponse>());
        }

        /// <summary>
        /// Удалить объявление.
        /// </summary>
        /// <param name="announcementsId">Идентификатор объявления.</param>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Сообщение об успешном удалении или ошибка 400, если не найдено.</returns>
        [HttpDelete("{announcementsId}/{userId}")]
        public IActionResult Delete(int announcementsId, int userId)
        {
            var announcement = Context.Announcements
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
