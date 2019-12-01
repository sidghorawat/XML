using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartEnrollmentFor911.Models;

namespace SmartEnrollmentFor911.Pages
{
    public class CrimeSurveysJsonModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        public CrimeSurveysJsonModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IList<CrimeSurvey> CrimeSurveys = new List<CrimeSurvey>();
        public JsonResult OnGet()
        {
            string line;
            string path = Path.Combine(_environment.ContentRootPath, "CrimeSurveys.txt");
            StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                string[] data = line.Split(',');
                CrimeSurvey crimeSurvey = new CrimeSurvey();
                crimeSurvey.FirstName = data[0];
                crimeSurvey.LastName = data[1];
                crimeSurvey.isSafe = Boolean.Parse(data[2]);
                crimeSurvey.ShiftCity = data[3];
                CrimeSurveys.Add(crimeSurvey);
            }
            file.Close();
            return new JsonResult(CrimeSurveys);
        }
    }
}