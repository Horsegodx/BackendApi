using BackendApi.Contracts.Planting;
using BackendApi.Contracts.PollAnswer;
using BackendApi.Controllers;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantingController : ControllerBase
    {
        public CoutryhouseContext Context { get; }

        public PlantingController(CoutryhouseContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Получить список всех посадок.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var plantings = Context.Plantings.ToList();
            var response = plantings.Adapt<List<GetPlantingResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получить посадку по идентификаторам.
        /// </summary>
        [HttpGet("{plantingId}/{plantId}")]
        public IActionResult GetById(int plantingId, int plantId)
        {
            var planting = Context.Plantings
                .FirstOrDefault(x => x.PlantingId == plantingId && x.PlantId == plantId);

            if (planting == null)
            {
                return BadRequest("Not Found");
            }

            return Ok(planting.Adapt<GetPlantingResponse>());
        }

        /// <summary>
        /// Добавить новую посадку.
        /// </summary>
        [HttpPost]
        public IActionResult Add(CreatePlantingRequest request)
        {
            var planting = request.Adapt<Planting>();
            Context.Plantings.Add(planting);
            Context.SaveChanges();
            return Ok(planting.Adapt<GetPlantingResponse>());
        }

        /// <summary>
        /// Обновить информацию о посадке.
        /// </summary>
        [HttpPut("{plantingId}/{plantId}")]
        public IActionResult Update(CreatePlantingRequest request, int plantingId, int plantId)
        {
            var existingPlanting = Context.Plantings
                .FirstOrDefault(x => x.PlantingId == plantingId && x.PlantId == plantId);

            if (existingPlanting == null)
            {
                return BadRequest("Not Found");
            }

            request.Adapt(existingPlanting);
            Context.SaveChanges();
            return Ok(existingPlanting.Adapt<GetPlantingResponse>());
        }

        /// <summary>
        /// Удалить посадку.
        /// </summary>
        [HttpDelete("{plantingId}/{plantId}")]
        public IActionResult Delete(int plantingId, int plantId)
        {
            var planting = Context.Plantings
                .FirstOrDefault(x => x.PlantingId == plantingId && x.PlantId == plantId);

            if (planting == null)
            {
                return BadRequest("Not Found");
            }

            Context.Plantings.Remove(planting);
            Context.SaveChanges();
            return Ok();
        }
    }
}










