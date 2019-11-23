using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data
{
    //Class used to verify if assync operations
    //were successufuly done. If not, the flag
    //is set to False and the error message is set.
    public class TAR//Table Applications Return
    {
        public int Id { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
