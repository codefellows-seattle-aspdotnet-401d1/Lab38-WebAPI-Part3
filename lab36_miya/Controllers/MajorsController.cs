using lab36_miya.Data;
using lab36_miya.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab36_miya.Controllers
{
    //below is a route token inside of attribute binding 
    [Route("api/[controller]")]
    public class MajorsController : ControllerBase
    {
        private readonly Lab36DbContext _context;

        //this constructor puts restraints on how we can refer to the dbcontext
        public MajorsController(Lab36DbContext context)
        {
            _context = context;
        }

        //Get
        [HttpGet]
        //get all of the lists in the database
        public IEnumerable<Majors> Get()
        {
            //the line below will return all items within ToDoItem database - no need for a LINQ query
            return _context.Majors;
        }

        //Get
        [HttpGet("{id:int?}")]
        public IActionResult Get(int id)
        {
            //we are getting the list that is associated with the specified id
            var getList = _context.Majors.FirstOrDefault(s => s.ID == id);

            //a call to the todo items, grabbing all items where listID == specified id
            Majors task = new Majors();

            task.Courses = _context.RequiredCoursework.Where(w => w.ListID == id).ToList();
            task.Name = getList.Name;

            return Ok(task);
        }

        //Post - creates a resource
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Majors major)
        {
            await _context.Majors.AddAsync(major);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = major.ID }, major);
        }

        //Put - updates something to the resource or creates resource
        //passing an ID (required) into PUT in order to check if something exists
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] Majors major)
        {
            //this will test to see if the model state coming in meets the requirements placed on the model using data annotations/model binding
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var check = _context.Majors.FirstOrDefault(i => i.ID == id);

            if (check != null)
            {
                check.Name = major.Name;
                _context.Update(check);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        //Delete
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _context.Majors.FirstOrDefault(d => d.ID == id);

            if (result != null)
            {
                _context.Majors.Remove(result);
                await _context.SaveChangesAsync();

                return Ok();
            }

            return BadRequest();

        }
    }


}
