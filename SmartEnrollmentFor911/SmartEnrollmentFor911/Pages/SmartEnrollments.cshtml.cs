using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CrimeIncident;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartEnrollment;

namespace SmartEnrollmentFor911.Pages
{
    public class SmartEnrollmentsModel : PageModel
    {
        public void OnGet()
        {
            String crimeIncidentJSON = GetData("https://data.cincinnati-oh.gov/resource/k59e-2pvf.json");
            var crimeIncidents = CrimeIncidents.FromJson(crimeIncidentJSON);
            ViewData["CrimeIncidents"] = crimeIncidents;


            String smart911EnrollmentJSON = GetData("https://data.cincinnati-oh.gov/resource/rtu7-isj6.json");
            var smart911Enrollments = Smart911Enrollment.FromJson(smart911EnrollmentJSON);
            ViewData["Smart911Enrollments"] = smart911Enrollments;

            IDictionary<long, CrimeIncident.CrimeIncidents> incidentsMap = new Dictionary<long, CrimeIncidents>();
            List<SmartEnrollment.Smart911Enrollment> enrollist = new List<Smart911Enrollment>();
            foreach (CrimeIncident.CrimeIncidents crInc in crimeIncidents)
            {
                if (!incidentsMap.ContainsKey(crInc.Zip))
                {
                    incidentsMap.Add(crInc.Zip, crInc);
                }
            }

            foreach (SmartEnrollment.Smart911Enrollment enroll in smart911Enrollments)
            {
                if (incidentsMap.ContainsKey(enroll.ZipCode))
                {
                    enrollist.Add(enroll);
                }
            }
            ViewData["Enrollist"] = enrollist;
        }

        public string GetData(string url)
        {
            String JSONString = "";
            using (var webClient = new WebClient())
            {
                JSONString = webClient.DownloadString(url);
            }
            return JSONString;
        }
    }

    
}