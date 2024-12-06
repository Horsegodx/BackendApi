using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        public CoutryhouseContext Context { get; }

        public PaymentsController(CoutryhouseContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Payment> payments = Context.Payments.ToList();
            return Ok(payments);
        }

        // Получить платеж по payments_id и user_id
        [HttpGet("{paymentsId}/{userId}")]
        public IActionResult GetById(int paymentsId, int userId)
        {
            Payment? payment = Context.Payments
                .Where(x => x.PaymentsId == paymentsId && x.UserId == userId)
                .FirstOrDefault();
            if (payment == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(payment);
        }

        // Добавить новый платеж
        [HttpPost]
        public IActionResult Add(Payment payment)
        {
            Context.Payments.Add(payment);
            Context.SaveChanges();
            return Ok(payment);
        }

        // Обновить платеж
        [HttpPut]
        public IActionResult Update(Payment payment)
        {
            var existingPayment = Context.Payments
                .Where(x => x.PaymentsId == payment.PaymentsId && x.UserId == payment.UserId)
                .FirstOrDefault();
            if (existingPayment == null)
            {
                return BadRequest("Not Found");
            }

            // Обновление значений
            Context.Entry(existingPayment).CurrentValues.SetValues(payment);
            Context.SaveChanges();
            return Ok(payment);
        }

        // Удалить платеж
        [HttpDelete("{paymentsId}/{userId}")]
        public IActionResult Delete(int paymentsId, int userId)
        {
            Payment? payment = Context.Payments
                .Where(x => x.PaymentsId == paymentsId && x.UserId == userId)
                .FirstOrDefault();
            if (payment == null)
            {
                return BadRequest("Not Found");
            }
            Context.Payments.Remove(payment);
            Context.SaveChanges();
            return Ok();
        }
    }
}
