using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data
{
    public class Event
    {
        public int EventId { get; set; }

        public User Creator { get; set; }

        public DateTime Date { get; set; }

        public String Name { get; set; }

        public float Cost { get; set; }

        public string Description { get; set; }

        public Location place { get; set; }
    }
}
