using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVCMeetingPlanner.Models
    
{
    public class TimeplannerModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string People { get; set; }

        [Display(Name = "Time start")]
        [DataType(DataType.Date)]
 
        public DateTime TimeStart { get; set; }

        [Display(Name = "Time end")]
        [DataType(DataType.Date)]
        public DateTime TimeEnd { get; set; }
    }
}
