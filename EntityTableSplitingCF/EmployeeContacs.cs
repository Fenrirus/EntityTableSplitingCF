using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityTableSplitingCF
{
    public class EmployeeContacs
    {
        public int EmployeeID { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string LandLine { get; set; }

        public Employee employee { get; set; }
    }
}