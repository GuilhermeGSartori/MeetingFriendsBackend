using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Data
{
    public class Location
    {
        [Key]
        public string LocationName { get; set; } //Even though name does not have an Id on the name, it's the key!

        public float Score { get; set; }
    }
}
