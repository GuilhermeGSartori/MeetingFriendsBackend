using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data
{
    public class Event
    {
        public int EventId { get; set; }//Entity Framework uses attribute with Id in the name as key (unique, incremented)

        public string Creator { get; set; }

        public string Date { get; set; }

        public string EventName { get; set; }

        public float Cost { get; set; }

        public string Description { get; set; }

        public string Place { get; set; }
    }
}
