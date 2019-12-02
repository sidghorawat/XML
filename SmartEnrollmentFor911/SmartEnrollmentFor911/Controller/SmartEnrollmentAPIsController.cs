using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CrimeIncident;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartEnrollment;
using SmartEnrollmentFor911.Models;

namespace SmartEnrollmentFor911.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartEnrollmentAPIsController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public SmartEnrollmentAPIsController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        // GET: api/SmartEnrollmentAPIs
        [HttpGet]
        public IList<SmartEnrollmentAPI> GetSmartEnrollmentAPI()
        {
            IList<SmartEnrollmentAPI> outputJson = new List<SmartEnrollmentAPI>();
            using (var webClient = new WebClient())
            {
                String crimeIncidentJSON = webClient.DownloadString("https://data.cincinnati-oh.gov/resource/k59e-2pvf.json");
                var crimeIncidents = CrimeIncidents.FromJson(crimeIncidentJSON);

                String smart911EnrollmentJSON = webClient.DownloadString("https://data.cincinnati-oh.gov/resource/rtu7-isj6.json");
                var smart911Enrollments = Smart911Enrollment.FromJson(smart911EnrollmentJSON);

                IDictionary<long, CrimeIncident.CrimeIncidents> incidentsMap = new Dictionary<long, CrimeIncidents>();

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
                        SmartEnrollmentAPI enrollment = new SmartEnrollmentAPI();
                        enrollment.Zipcode = enroll.ZipCode;
                        enrollment.WebEnrollments = enroll.WebEnrollments;
                        enrollment.AppEnrollments = enroll.AppEnrollments;
                        enrollment.TotalEnrollments = enroll.TotalEnrollments;
                        outputJson.Add(enrollment);
                    }
                }
            }
            return outputJson;
        }
    }
}
