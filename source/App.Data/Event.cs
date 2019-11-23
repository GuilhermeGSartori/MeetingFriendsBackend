using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data
{
    public class Event
    {
        public int EventId { get; set; }

        public string Creator { get; set; }

        public string Date { get; set; }

        public string Name { get; set; }

        public float Cost { get; set; }

        public string Description { get; set; }

        public Location Place { get; set; }
    }
}
