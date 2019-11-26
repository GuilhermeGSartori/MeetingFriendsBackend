using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Data
{
    public class LocationTAR//Table Applications Return
    {
        [Key]
        public string Name { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
