using lab36_miya.Data;
using lab36_miya.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab36_miya.Controllers
{
    //below is a route token inside of attribute routing - curly braces make the routing more dynamic
    //we are using ControllerBase instead of Controller here because this will not be a front-facing app
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly Lab36DbContext _context;

        public CoursesController(Lab36DbContext context)
        {
            _context = context;
        }

        //Get
        //this Get was added in order to view all items in the database at once with a single get request(not including an ID)
        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<RequiredCoursework> Get()
        {
            return _context.RequiredCoursework;
        }

        //Get
        //below is an example of model binding with id constraints which are optional
        [HttpGet ("{id:int?}")]
        //adding this form of content negotiation in the hopes that it will restrict this Get method to only produce results in XML
        [Produces("application/xml")]
        public IActionResult Get(int id)
        {
            //storing a LINQ query containing a lambda statement within an anonymous variable
            var result = _context.RequiredCoursework.FirstOrDefault(h => h.ID == id);
            //returning a good status code (200)
            return Ok(result);
        }

        //Post - creates a resource
        //from body in a form of model binding that controls requirements added to the database
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RequiredCoursework requirement)
        {
            await _context.AddAsync(requirement);
            await _context.SaveChangesAsync();


            //this will return a get URL that references the new requirement added
            return CreatedAtAction("Get", new {id = requirement.ID }, requirement);
        }

        //Put - updates something to the resource or creates resource
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] RequiredCoursework requirement)
        {
            //this will test to see if the model state coming in meets the requirements placed on the model using data annotations/model binding
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            var check = _context.RequiredCoursework.FirstOrDefault(v => v.ID == id);

            if (check != null)
            {
                check.Class = requirement.Class;
                check.IsComplete = requirement.IsComplete;
                _context.Update(check);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = requirement.ID }, requirement);
            }
            //attempting to find a way to use Put when an item is not there to be replaced
            else if (check == null)
            {
                await Post(requirement);
            }
            return BadRequest();
        }

        //Delete
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _context.RequiredCoursework.FirstOrDefault(w => w.ID == id);

            if(result != null)
            {
                _context.RequiredCoursework.Remove(result);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}
