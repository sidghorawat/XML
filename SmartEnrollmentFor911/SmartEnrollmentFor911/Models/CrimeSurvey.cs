using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartEnrollmentFor911.Models
{
    public class CrimeSurvey
    {
        public int ID { get; set; }
        [Display (Name = "First Name" )]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "City You Live")]
        public string CityYouLive { get; set; }
        [Display(Name = "Do you feel your city safe?")]
        public bool isSafe { get; set; }
        [Display(Name = "Which city you feel is the safest in US")]
        public string ShiftCity { get; set; }
    }
}
