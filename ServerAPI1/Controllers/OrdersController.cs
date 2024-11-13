using System.Reflection;
using Core1;
using Microsoft.AspNetCore.Mvc;
using ServerAPI1.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerAPI1.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class OrderController : ControllerBase
        {
            private readonly IOrderRepository _orderRepository; // opretter et privat felt af typen IOrderRepository. Ved at tildele readonly kan dette felt kun sættes i konstruktøren, hvilket sikrer, at den ikke ændres i løbet af controllerens levetid.

            public OrderController(IOrderRepository orderRepository) // Dette giver controlleren adgang til repository-metoder, som bruges til at håndtere data for Order.
            {
                _orderRepository = orderRepository;
            }

            [HttpGet]
            public ActionResult<IEnumerable<Order>> GetAllOrders()
            {
                return Ok(_orderRepository.GetAll());
            }

            [HttpGet("{id}")]
            public ActionResult<Order> GetOrderById(int id)
            {
                var order = _orderRepository.GetById(id);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }

            [HttpPost]
            public ActionResult CreateOrder(Order order)
            {
                _orderRepository.Add(order);
                return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, order);
            }

            [HttpPut("{id}")]
            public ActionResult UpdateOrder(int id, Order order)
            {
                var existingOrder = _orderRepository.GetById(id);
                if (existingOrder == null)
                {
                    return NotFound();
                }
                order.OrderId = existingOrder.OrderId;
                _orderRepository.Update(order);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public ActionResult DeleteOrder(int id)
            {
                var order = _orderRepository.GetById(id);
                if (order == null)
                {
                    return NotFound();
                }

                _orderRepository.Delete(order);
                return NoContent();
            }
        }
    }
