using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week8Project.Data;
using Week8Project.Models;

namespace Week8Project.Controllers
{
    //Controller Class for interacting with the API
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        //Set up dependancy injection for the context
        private readonly PokemonDbContext _context;

        //Construct the controller with the injected context
        public PokemonController(PokemonDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Produces("application/xml")]
        //Get all Pokemon in the db and return in xml
        public IEnumerable<Pokemon> Get()
        {
            return _context.Pokemon;
        }

        //Get a Pokemon from the db and return in json
        [HttpGet("{id:int?}")]
        [Produces("application/json")]
        //Require int to target pokemon to get
        public IActionResult Get(int id)
        {
            
            //find the pokemon by its's ID
            var result = _context.Pokemon.FirstOrDefault(p => p.ID == id);
            //return a status 200 and the requested pokemon
            return Ok(result);
        }

        //Post a new Pokemon to the db
        //Extract the pokemon to add from the req body
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Pokemon newPMon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //Add the new pokemon to the db
            await _context.Pokemon.AddAsync(newPMon);
            //Save the change to the db
            await _context.SaveChangesAsync();
            //return creation success status and the pokemon plus its location
            return CreatedAtAction("Get", new { id = newPMon.ID, newPMon });
        }

        //Put
        //Update an existing Pokemon
        [HttpPut("{id:int?}")]
        public async Task<IActionResult> Put (int id, [FromBody]Pokemon PmonToUpdate)
        {
            //Check model state
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //select Pmon from db by id
            var thePmon = _context.Pokemon.FirstOrDefault(p => (p.ID == id));
            //If Pmon is found, update it with the new data.
            if (thePmon != null)
            {
                thePmon.Species = PmonToUpdate.Species;
                thePmon.Type = PmonToUpdate.Type;
                _context.Update(thePmon);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = thePmon.ID, thePmon });
            }

            //If Pmon is not found, create one using the supplied data
            return await Post(PmonToUpdate);
        }

        //Delete
        //Deletes the specified Pokemon
        [HttpDelete("{id:int?}")]
        public async Task<IActionResult> Delete(int id)
        {
            //Select Pmon by id
            var thePmon = _context.Pokemon.FirstOrDefault(p => (p.ID == id));
            //If found, delete it.
            if (thePmon != null)
            {
                _context.Pokemon.Remove(thePmon);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }
    }
}
