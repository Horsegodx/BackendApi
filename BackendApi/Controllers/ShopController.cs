using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        public CoutryhouseContext Context { get; }

        public ShopController(CoutryhouseContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Получить все магазины.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Shop> shops = Context.Shops.ToList();
            return Ok(shops);
        }

        /// <summary>
        /// Получить магазин по его идентификатору.
        /// </summary>
        [HttpGet("{shopId}")]
        public IActionResult GetById(int shopId)
        {
            Shop? shop = Context.Shops
                .Where(x => x.ShopId == shopId)
                .FirstOrDefault();
            if (shop == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(shop);
        }

        /// <summary>
        /// Добавить новый магазин.
        /// </summary>
        [HttpPost]
        public IActionResult Add(Shop shop)
        {
            Context.Shops.Add(shop);
            Context.SaveChanges();
            return Ok(shop);
        }

        /// <summary>
        /// Обновить информацию о магазине.
        /// </summary>
        [HttpPut]
        public IActionResult Update(Shop shop)
        {
            var existingShop = Context.Shops
                .Where(x => x.ShopId == shop.ShopId)
                .FirstOrDefault();
            if (existingShop == null)
            {
                return BadRequest("Not Found");
            }

            // Обновление значений
            Context.Entry(existingShop).CurrentValues.SetValues(shop);
            Context.SaveChanges();
            return Ok(shop);
        }

        /// <summary>
        /// Удалить магазин.
        /// </summary>
        [HttpDelete("{shopId}")]
        public IActionResult Delete(int shopId)
        {
            Shop? shop = Context.Shops
                .Where(x => x.ShopId == shopId)
                .FirstOrDefault();
            if (shop == null)
            {
                return BadRequest("Not Found");
            }
            Context.Shops.Remove(shop);
            Context.SaveChanges();
            return Ok();
        }
    }
}
