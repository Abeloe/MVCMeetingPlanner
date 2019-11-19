using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMeetingPlanner.Models
{
    public class MeetingTitleViewModel
    {
        public List<TimeplannerModel> TimeplannerModels { get; set; }
        public SelectList SortTitels { get; set; }
        public SelectList SortPeoples { get; set; }
        public string MeetingTitle { get; set; }
        public string SearchString { get; set; }
    }
}
