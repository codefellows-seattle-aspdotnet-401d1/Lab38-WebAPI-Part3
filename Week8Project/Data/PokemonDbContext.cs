using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week8Project.Models;

namespace Week8Project.Data
{
    public class PokemonDbContext: DbContext
    {
        public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options)
        {

        }
  
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<TypeList> TypeList { get; set; }
    }
}
