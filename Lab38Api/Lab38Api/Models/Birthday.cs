using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab38Api.Models
{
    public class Birthday
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<BirthdayPlan> Tasks { get; set; }
    }
}
