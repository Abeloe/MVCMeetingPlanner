using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCMeetingPlanner.Controllers
{
    public class MeetingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        // 
        // GET: /Planner/

        //public string Index()
        //{
        //    return "Plan that meeting";
        //}

        // 
        // GET: /Planner/Welcome
        public IActionResult Welcome(string name, int NumTimes = 1)
        {
            ViewData["Message"] = "Hello" + name;
            ViewData["NumTimes"] = NumTimes;


            return View();
        }
    }
}