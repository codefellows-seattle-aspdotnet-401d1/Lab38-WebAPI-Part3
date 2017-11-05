using Lab38George.Data;
using Lab38George.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab38George.Controllers
{
    public class PartsController : ControllerBase
    {
        // dependency injection
        private readonly PartsDbContext _context;
        public PartsController(PartsDbContext context)
        {
            _context = context;
        }

        // Get one
        // Model binding to grab an integer from the URL
        [HttpGet("{id:int?}")]
        // id constraint to make sure we're only accepting an int
        public IActionResult Get(int id)
        {
            // grabs the first record from the database with a matching id to the one entered
            var result = _context.Parts.FirstOrDefault(p => p.PartID == id);
            return Ok(result);
        }

        // Get all
        [HttpGet]
        [Produces("application/XML")]
        public IEnumerable<Parts> Get()
        {
            // just grabs all the items in the database (I couldn't resist after class today)
            return _context.Parts;
        }

        // Post
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Parts part)
        {
            // if our model state isn't valid just return a bad request and don't try to do anything
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // add part to database
            _context.Add(part);
            // wait for the response from the database saying the add was successful
            await _context.SaveChangesAsync();
            // return information about the addtion we just did
            return CreatedAtAction("Get", new { id = part.PartID }, part);
        }

        // Put
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody]Parts part)
        {
            // if our model state isn't valid just return a bad request and don't try to do anything
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // find the record in the database that matches the id we are looking for
            var check = _context.Parts.FirstOrDefault(i => i.PartID == id);
            // if we find something in the previous line we execute this code
            if (check != null)
            {
                // change each of the values to the new values we are replacing them with
                check.Name = part.Name;
                check.Quantity = part.Quantity;
                check.Details = part.Details;
                // send the actual update request to the database
                _context.Update(check);
                // wait to get confirmation the database finished
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        // Delete
        [HttpDelete("(id:int)")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _context.Parts.FirstOrDefault(d => d.PartID == id);
            if (result != null)
            {
                _context.Parts.Remove(result);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}
