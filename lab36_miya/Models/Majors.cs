using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab36_miya.Models
{
    public class Majors
    {
        public int ID
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public List<RequiredCoursework> Courses
        {
            get; set;
        }
    }
}
