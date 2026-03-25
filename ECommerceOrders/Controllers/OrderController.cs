using ECommerceOrders.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceOrders.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        [Route("order")]
        public IActionResult Index(Order order)
        {
            int orderId = Random.Shared.Next(1, 1000);
            order.OrderNo = orderId;
            double totalPrice = 0;
            foreach (var item in order.Products)
            {
                totalPrice += item.Price * item.Quantity;
            }
            if(order.InvoicePrice != totalPrice)
            {
                return BadRequest("Invoice price does not match the total price of the products.");
            }
            if(!ModelState.IsValid)
            {
                string errorMessage = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                return BadRequest(errorMessage);
            }
            return Ok(order);
        }
    }
}
