using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoShackBLL;
using VideoShackBLL.BusinessObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/values
        [HttpGet]
        public IEnumerable<OrderBO> Get()
        {
            return facade.GetOrderService.RetrieveAllOrders();
        }

        // GET: api/Order/5
        [HttpGet("{id}", Name = "Get")]
        public OrderBO Get(int id)
        {
            return facade.GetOrderService.RetrieveOrder(id);
        }

        // POST: api/Order
        [HttpPost]
        public IActionResult Post([FromBody]OrderBO order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.GetOrderService.Create(order));
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]OrderBO order)
        {
            if (id != order.OrderId)
            {
                return StatusCode(405, "Path Id does not match Movie ID in json object");
            }
            try
            {
                return Ok(facade.GetOrderService.Update(order));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.GetOrderService.Delete(id);
        }
    }
}
