using Lab38Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab38Api.Data
{
    public class BirthdayPlanDbContext : DbContext
    {
        public BirthdayPlanDbContext(DbContextOptions<BirthdayPlanDbContext> options) : base(options)
        {

        }
        public DbSet<BirthdayPlan> BirthdayPlan { get; set; }
        public DbSet<Birthday> BirthdayList { get; set; }
    }
}
