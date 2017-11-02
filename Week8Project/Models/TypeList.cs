using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week8Project.Models
{
    public class TypeList
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public List<Pokemon> Members { get; set; }
    }
}
