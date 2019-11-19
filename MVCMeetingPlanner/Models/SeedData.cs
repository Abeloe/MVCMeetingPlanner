using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCMeetingPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMeetingPlanner.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MVCMeetingPlannerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MVCMeetingPlannerContext>>()))
            {
                // Look for any movies.
                if (context.TimeplannerModel.Any())
                {
                    return;   // DB has been seeded
                }

                context.TimeplannerModel.AddRange(
                    new TimeplannerModel
                    {
                        Title = "Salary meeting",
                        People = "Mikkel",
                        TimeStart = DateTime.Parse("1989-2-12"),
                        TimeEnd = DateTime.Parse("1990-2-12"),
                    },

                    new TimeplannerModel
                    {
                        Title = "Salary meeting",
                        People = "Anna",
                        TimeStart = DateTime.Parse("2020-2-12"),
                        TimeEnd = DateTime.Parse("2021-2-12"),
                    },

                    new TimeplannerModel
                    {
                        Title = "Salary meeting",
                        People = "Tomas",
                        TimeStart = DateTime.Parse("1995-2-12"),
                        TimeEnd = DateTime.Parse("1996-2-12"),
                    },

                    new TimeplannerModel
                    {
                        Title = "Salary meeting",
                        People = "Christpher",
                        TimeStart = DateTime.Parse("2019-2-12"),
                        TimeEnd = DateTime.Parse("2020-2-12"),
                    }

                );
                context.SaveChanges();
            }
        }
    }
}
