using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QuickType;
using QuickType911Enrollment;

namespace SmartEnrollmentFor911.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            using (var webClient = new WebClient())
            {
                String crimeIncidentJSON = webClient.DownloadString("https://data.cincinnati-oh.gov/resource/k59e-2pvf.json");
                var crimeIncidents = CrimeIncidents.FromJson(crimeIncidentJSON);
                ViewData["CrimeIncidents"] = crimeIncidents;


                String smart911EnrollmentJSON = webClient.DownloadString("https://data.cincinnati-oh.gov/resource/rtu7-isj6.json");
                var smart911Enrollments = Smart911Enrollment.FromJson(smart911EnrollmentJSON);
                ViewData["Smart911Enrollments"] = smart911Enrollments;

                IDictionary<long, QuickType.CrimeIncidents> incidentsMap = new Dictionary<long, CrimeIncidents>();
                List<QuickType911Enrollment.Smart911Enrollment> enrollist = new List<Smart911Enrollment>();
                foreach (QuickType.CrimeIncidents crInc in crimeIncidents)
                {
                    if (!incidentsMap.ContainsKey(crInc.Zip))
                    {
                        incidentsMap.Add(crInc.Zip, crInc);
                    }
                }

                foreach (QuickType911Enrollment.Smart911Enrollment enroll in smart911Enrollments)
                {
                    if (incidentsMap.ContainsKey(enroll.ZipCode))
                    {
                        enrollist.Add(enroll);
                    }
                }
                ViewData["Enrollist"] = enrollist;
            }
        }
    }
}
