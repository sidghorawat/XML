using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartEnrollmentFor911.Models
{
    public class SmartEnrollmentAPI
    {
        public int id { get; set; }
        public long Zipcode { get; set; }
        public long WebEnrollments { get; set; }
        public long AppEnrollments { get; set; }
        public long TotalEnrollments { get; set; }
    }
}
