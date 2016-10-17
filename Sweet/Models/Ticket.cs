using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sweet.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Resolve Resolve { get; set; }
        //public string UserName { get; set; }
        //public DateTime Meeting { get; set; }

    }
    public enum Resolve
    {
        Open = 1,
        Closed
    }

}