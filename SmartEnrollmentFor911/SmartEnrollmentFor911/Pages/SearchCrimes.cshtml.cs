using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrimeIncident;
using SmartEnrollment;

namespace SmartEnrollmentFor911.Pages
{
    public class SearchCrimesModel : PageModel
    {
        public bool searchFinished { get; set; }
        [BindProperty]
        public long zipSearch { get; set; }
        public CrimeIncident.CrimeIncidents[] crimes;
        public SmartEnrollment.Smart911Enrollment[] enrollments;
        public CrimeIncident.CrimeIncidents[] crimesFiltered;
        public SmartEnrollment.Smart911Enrollment[] enrollmentsFiltered;
        public void OnGet()
        {

        }
        public void OnPost()
        {
            using (var webClient = new WebClient())
            {
                String crimeIncidentJSON = webClient.DownloadString("https://data.cincinnati-oh.gov/resource/k59e-2pvf.json");
                crimes = CrimeIncidents.FromJson(crimeIncidentJSON);


                String smart911EnrollmentJSON = webClient.DownloadString("https://data.cincinnati-oh.gov/resource/rtu7-isj6.json");
                enrollments = Smart911Enrollment.FromJson(smart911EnrollmentJSON);

                crimesFiltered = crimes.Where(x => x.Zip == zipSearch).ToArray();
                enrollmentsFiltered = enrollments.Where(x => x.ZipCode == zipSearch).ToArray();

                ViewData["CrimeIncidents"] = crimesFiltered;
                ViewData["Smart911Enrollments"] = enrollmentsFiltered;
            }
            searchFinished = true;
        }
    }
}