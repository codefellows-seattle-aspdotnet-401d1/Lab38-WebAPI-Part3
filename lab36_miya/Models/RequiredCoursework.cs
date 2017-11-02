using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab36_miya.Models
{
    public class RequiredCoursework
    {
        public int ID
        {
            get; set;
        }

        [MinLength(4)]
        public string Class
        {
            get; set;
        }

        public bool IsComplete
        {
            get; set;
        }

        public int ListID
        {
            get; set;
        }
    }
}
