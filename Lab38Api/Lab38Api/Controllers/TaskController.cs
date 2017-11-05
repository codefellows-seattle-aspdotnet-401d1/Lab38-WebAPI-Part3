using Lab38Api.Data;
using Lab38Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab38Api.Controllers
{
    [Route("api/[Controller]")]
    public class TaskController : ControllerBase
    {
        private readonly BirthdayPlanDbContext _context;
        // dependency injection for DbContext
        public TaskController(BirthdayPlanDbContext context)
        {
            _context = context;
        }

        //Get method for a single item from the Db
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var result = _context.BirthdayPlan.FirstOrDefault(c => c.ID == id);
            return Ok(result);
        }

        //Http Get method to retrieve all items
        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<BirthdayPlan> Get()
        {
            return _context.BirthdayPlan;
        }

        //Post method to add a new item
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BirthdayPlan plan)
        {
            await _context.AddAsync(plan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = plan.ID }, plan);
        }

        //Put method to update an item
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] BirthdayPlan plan)
        {
            if (!ModelState.IsValid)
            {
                //returns a BadRequest with a message for what part of the ModelState was invalid
                return BadRequest(ModelState);
            }
            var Put = _context.BirthdayPlan.FirstOrDefault(p => p.ID == id);

            if (Put != null)
            {
                //Replaces the data in the variable with the new data brought in
                Put.Task = plan.Task;
                Put.IsComplete = plan.IsComplete;
                _context.Update(Put);

                await _context.SaveChangesAsync();
                return Ok();

            }

            else
            {
                return BadRequest();
            }
        }

        //Deletes the data with the id that is brought in
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _context.BirthdayPlan.FirstOrDefault(d => d.ID == id);

            if (result != null)
            {
                _context.BirthdayPlan.Remove(result);

                await _context.SaveChangesAsync();

                return Ok();
            }
            return BadRequest();
        }

    }
}
