using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartEnrollmentFor911.Models;

namespace SmartEnrollmentFor911.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimeSurveysController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        public CrimeSurveysController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        // GET: api/CrimeSurveys
        [HttpGet]
        public ActionResult<IEnumerable<CrimeSurvey>> GetCrimeSurvey()
        {
            List<CrimeSurvey> crimeSurveysList = new List<CrimeSurvey>();
            string line;
            string path = Path.Combine(_environment.ContentRootPath, "CrimeSurveysFile.txt");
            StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                string[] data = line.Split(',');
                CrimeSurvey crimeSurvey = new CrimeSurvey();
                crimeSurvey.FirstName = data[0];
                crimeSurvey.LastName = data[1];
                crimeSurvey.CityYouLive = data[2];
                crimeSurvey.isSafe = Boolean.Parse(data[3]);
                crimeSurvey.ShiftCity = data[4];
                crimeSurveysList.Add(crimeSurvey);
            }
            file.Close();
            return crimeSurveysList;
        }
    }
}
