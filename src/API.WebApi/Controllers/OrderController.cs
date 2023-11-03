using API.ApplicationCore.DTOs;
using API.ApplicationCore.Exceptions;
using API.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet()]
        public ActionResult<List<OrderResponse>> GetOrders([FromQuery] Guid orderId)
        {
            if (orderId != new Guid())
            {
                try
                {
                    var order = this.orderRepository.GetOrderById(orderId);
                    return Ok(order);
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }
            }

            else
            {
                return Ok(this.orderRepository.GetOrders());
            }
        }

        [HttpPost()]
        public ActionResult CreateOrder([FromQuery] Guid userId, [FromBody] CreateOrderRequest request, [FromQuery] Guid[] productIds)
        {
            var order = this.orderRepository.CreateOrder(userId, request, productIds);
            return Ok(order);
        }

        [HttpPut()]
        public ActionResult UpdateOrder([FromQuery] Guid oid, [FromBody] UpdateOrderRequest request, [FromQuery] Guid[] productIds)
        {
            try
            {
                var product = this.orderRepository.UpdateOrder(oid, request, productIds);
                return Ok(product);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete()]
        public ActionResult DeleteOrder([FromQuery] Guid oid)
        {
            try
            {
                this.orderRepository.DeleteOrderById(oid);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
