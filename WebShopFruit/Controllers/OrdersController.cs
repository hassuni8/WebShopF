using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ApplicationServices;
using Core.Entity;
using Microsoft.AspNetCore.Mvc;



namespace WebShopFruit.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return Ok(_orderService.GetAll());
        }



        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            if (id < 1) return BadRequest("Id has to be higher than 1");
            return _orderService.FindOrderById(id);
        }


        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            return _orderService.CreateOrder(order);
        }


        [HttpPut("{id}")]
        public ActionResult<Order> Put(int id, [FromBody] Order order)
        {
            if (id < 1 || id != order.Id)
            {
                return BadRequest("The ids must match");
            }

            _orderService.UpdateOrder(order);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Order> Delete(int id)
        {
            Order order = _orderService.DeleteOrder(id);
            if (order == null)
            {
                return BadRequest("Id must be the same as order Id");
            }
            return Ok("Order with id: " + id + " has been deleted");
        }
    }
}
