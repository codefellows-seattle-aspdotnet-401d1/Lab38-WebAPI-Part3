using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab38Api.Models
{
    public class BirthdayPlan
    {
        public int ID { get; set; }
        public string Task { get; set; }
        public bool IsComplete { get; set; }
        public int BirthdayID { get; set; }
    }
}
