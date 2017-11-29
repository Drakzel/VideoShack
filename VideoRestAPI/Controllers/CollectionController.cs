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
    public class CollectionController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/values
        [HttpGet]
        public IEnumerable<CollectionBO> Get()
        {
            return facade.GetCollectionService.RetrieveAllCollections();
        }

        // GET: api/Collection/5
        [HttpGet("{id}", Name = "GetCollection")]
        public CollectionBO Get(int id)
        {
            return facade.GetCollectionService.RetrieveCollection(id);
        }

        // POST: api/Order
        [HttpPost]
        public IActionResult Post([FromBody]CollectionBO collection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.GetCollectionService.Create(collection));
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CollectionBO collection)
        {
            if (id != collection.CollectionId)
            {
                return StatusCode(405, "Path Id does not match Movie ID in json object");
            }
            try
            {
                return Ok(facade.GetCollectionService.Update(collection));
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
            facade.GetCollectionService.Delete(id);
        }
    }
}
