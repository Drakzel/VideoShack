using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoShackBLL;
using VideoShackBLL.BusinessObjects;

namespace VideoRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        BLLFacade facade = new BLLFacade();
        // GET: api/Movie
        [HttpGet]
        public IEnumerable<MovieBO> Get()
        {
            return facade.GetVideoService.RetrieveAllMovies();
        }

        // GET: api/Movie/5
        [HttpGet("{id}", Name = "Get")]
        public MovieBO Get(int id)
        {
            return facade.GetVideoService.RetrieveById(id);
        }
        
        // POST: api/Movie
        [HttpPost]
        public IActionResult Post([FromBody]MovieBO movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(facade.GetVideoService.Create(movie));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
        
        // PUT: api/Movie/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]MovieBO movie)
        {
            if (id != movie.Id)
            {
                return StatusCode(405, "Path Id does not match Movie ID in json object");
            }
            try
            {
                return Ok(facade.GetVideoService.Update(movie));
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
            facade.GetVideoService.DeleteMovie(id);
        }
    }
}
