﻿using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WateringScheduleController : ControllerBase
    {
        public CoutryhouseContext Context { get; }

        public WateringScheduleController(CoutryhouseContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Получить все расписания полива.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<WateringSchedule> schedules = Context.WateringSchedules.ToList();
            return Ok(schedules);
        }

        /// <summary>
        /// Получить расписание полива по идентификатору расписания полива и идентификатору растения.
        /// </summary>
        [HttpGet("{wateringScheduleId}/{plantId}")]
        public IActionResult GetById(int wateringScheduleId, int plantId)
        {
            WateringSchedule? schedule = Context.WateringSchedules
                .Where(x => x.WateringScheduleId == wateringScheduleId && x.PlantId == plantId)
                .FirstOrDefault();
            if (schedule == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(schedule);
        }

        /// <summary>
        /// Добавить новое расписание полива.
        /// </summary>
        [HttpPost]
        public IActionResult Add(WateringSchedule schedule)
        {
            Context.WateringSchedules.Add(schedule);
            Context.SaveChanges();
            return Ok(schedule);
        }

        /// <summary>
        /// Обновить существующее расписание полива.
        /// </summary>
        [HttpPut]
        public IActionResult Update(WateringSchedule schedule)
        {
            var existingSchedule = Context.WateringSchedules
                .Where(x => x.WateringScheduleId == schedule.WateringScheduleId && x.PlantId == schedule.PlantId)
                .FirstOrDefault();
            if (existingSchedule == null)
            {
                return BadRequest("Not Found");
            }

            // Обновление значений
            Context.Entry(existingSchedule).CurrentValues.SetValues(schedule);
            Context.SaveChanges();
            return Ok(schedule);
        }

        /// <summary>
        /// Удалить расписание полива.
        /// </summary>
        [HttpDelete("{wateringScheduleId}/{plantId}")]
        public IActionResult Delete(int wateringScheduleId, int plantId)
        {
            WateringSchedule? schedule = Context.WateringSchedules
                .Where(x => x.WateringScheduleId == wateringScheduleId && x.PlantId == plantId)
                .FirstOrDefault();
            if (schedule == null)
            {
                return BadRequest("Not Found");
            }
            Context.WateringSchedules.Remove(schedule);
            Context.SaveChanges();
            return Ok();
        }
    }
}
