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
    public class TypeListController : ControllerBase
    {
        //Set up dependancy injection for the context
        private readonly PokemonDbContext _context;

        //Construct the controller with the injected context
        public TypeListController(PokemonDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Produces("application/xml")]
        //Get all Pokemon in the db and return in xml
        public IEnumerable<string> Get()
        {
            var list = _context.TypeList;
            List<string> listNames = new List<string>();
            foreach (var item in list)
            {
                listNames.Add(item.Type);
            }
            return (listNames);
        }

        //Get a TypeList and its members from the db and return in json
        [HttpGet("{type}")]
        [Produces("application/json")]
        //Require string to target TypeList to get
        public IActionResult Get(string type)
        {
            //find the TypeList by its's Type
            var result = _context.TypeList.FirstOrDefault(p => p.Type == type);

            TypeList task = new TypeList();

            //Populate members with pokemon of matching Type
            task.Members = _context.Pokemon.Where(i => i.Type == type).ToList();
            task.Type = type;

            //return a status 200 and the requested pokemon
            return Ok(task);
        }

        //Post a new TypeList to the db
        //Extract the TypeList to add from the req body
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TypeList newList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //Add the new TypeList to the db
            await _context.TypeList.AddAsync(newList);
            //Save the change to the db
            await _context.SaveChangesAsync();
            //return creation success status and the TypeList plus its location
            return CreatedAtAction("Get", new { id = newList.ID, newList });
        }

        //Put
        //Update an existing TypeList
        [HttpPut]
        public async Task<IActionResult> Put(string type, [FromBody]TypeList listToUpdate)
        {
            //Check model state
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //select Pmon from db by id
            var theList = _context.TypeList.FirstOrDefault(p => (p.Type == type));
            //If List is found, update it with the new data.
            if (theList != null)
            {
                theList.Type = listToUpdate.Type;
                _context.Update(theList);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = theList.ID, theList });
            }

            //If Pmon is not found, create one using the supplied data
            return await Post(listToUpdate);
        }

        //Delete
        //Deletes the specified TypeList
        [HttpDelete]
        public async Task<IActionResult> Delete(string type)
        {
            //Select Pmon by id
            var theList = _context.TypeList.FirstOrDefault(p => (p.Type == type));
            //If found, delete it.
            if (theList != null)
            {
                _context.TypeList.Remove(theList);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }

    }
}
