using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data
{
    public class User
    {
        public int UserId { get; set; } //EF will treat this as primary key as it has Id on the name... Using "Add" will increment!

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
