using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCMeetingPlanner.Models;

namespace MVCMeetingPlanner.Data
{
    public class MVCMeetingPlannerContext : DbContext
    {
        public MVCMeetingPlannerContext (DbContextOptions<MVCMeetingPlannerContext> options)
            : base(options)
        {
        }

        public DbSet<TimeplannerModel> TimeplannerModel { get; set; }
    }
}
