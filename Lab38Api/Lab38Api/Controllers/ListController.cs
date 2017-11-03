using Lab38Api.Data;
using Lab38Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab38Api.Controllers
{
    [Route("api/[controller]")]
    public class ListController : ControllerBase
    {
        private readonly BirthdayPlanDbContext _context;

        public ListController(BirthdayPlanDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Birthday> Get()
        {
            return _context.BirthdayList;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var GetList = _context.BirthdayList.FirstOrDefault(g => g.ID == id);

            Birthday birthday = new Birthday();

            birthday.Tasks = _context.BirthdayPlan.Where(a => a.BirthdayID == id).ToList();
            birthday.Name = GetList.Name;

            return Ok(birthday);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Birthday plan)
        {
            await _context.BirthdayList.AddAsync(plan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = plan.ID }, plan);
        }

        [HttpDelete("{id=int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ResultList = _context.BirthdayList.FirstOrDefault(l => l.ID == id);
            var ResultTasks = _context.BirthdayPlan.Where(t => t.BirthdayID == id);

            if(ResultList != null)
            {
                foreach(var n in ResultTasks)
                {
                _context.BirthdayPlan.Remove(n);
                }

                _context.BirthdayList.Remove(ResultList);
                await _context.SaveChangesAsync();

                return Ok();
            }
            return BadRequest();
            
        }
    }
}
