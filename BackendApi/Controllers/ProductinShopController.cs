using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductinShopController : ControllerBase
    {
        public CoutryhouseContext Context { get; }

        public ProductinShopController(CoutryhouseContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ProductInShop> productsInShop = Context.ProductInShops.ToList();
            return Ok(productsInShop);
        }

        // Получить товар по product_id и shop_id
        [HttpGet("{productId}/{shopId}")]
        public IActionResult GetById(int productId, int shopId)
        {
            ProductInShop? productInShop = Context.ProductInShops
                .Where(x => x.ProductId == productId && x.ShopId == shopId)
                .FirstOrDefault();
            if (productInShop == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(productInShop);
        }

        // Добавить новый товар в магазин
        [HttpPost]
        public IActionResult Add(ProductInShop productInShop)
        {
            Context.ProductInShops.Add(productInShop);
            Context.SaveChanges();
            return Ok(productInShop);
        }

        // Обновить информацию о товаре в магазине
        [HttpPut]
        public IActionResult Update(ProductInShop productInShop)
        {
            var existingProductInShop = Context.ProductInShops
                .Where(x => x.ProductId == productInShop.ProductId && x.ShopId == productInShop.ShopId)
                .FirstOrDefault();
            if (existingProductInShop == null)
            {
                return BadRequest("Not Found");
            }

            // Обновление значений
            Context.Entry(existingProductInShop).CurrentValues.SetValues(productInShop);
            Context.SaveChanges();
            return Ok(productInShop);
        }

        // Удалить товар из магазина
        [HttpDelete("{productId}/{shopId}")]
        public IActionResult Delete(int productId, int shopId)
        {
            ProductInShop? productInShop = Context.ProductInShops
                .Where(x => x.ProductId == productId && x.ShopId == shopId)
                .FirstOrDefault();
            if (productInShop == null)
            {
                return BadRequest("Not Found");
            }
            Context.ProductInShops.Remove(productInShop);
            Context.SaveChanges();
            return Ok();
        }
    }
}
