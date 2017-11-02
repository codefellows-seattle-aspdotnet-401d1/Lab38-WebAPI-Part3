using lab36_miya.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab36_miya.Data
{
    public class Lab36DbContext : DbContext
    {
        //public Lab36DbContext()
        //{
        //}

        public Lab36DbContext(DbContextOptions<Lab36DbContext> options) : base(options)
        {

        }

        public DbSet<RequiredCoursework> RequiredCoursework
        {
            get; set;
        }
    }
}
