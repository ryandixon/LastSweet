using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sweet.Models
{
    public class Meeting
    {
        public int MeetingId { get; set; }
        public string UserName { get; set; }
        [Display(Name = "Schedule Date")]
        [DataType(DataType.Date)]
        public DateTime Schedule { get; set; }
        public string Time { get; set; }
    }
}