using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmartEnrollmentFor911.Models;

namespace SmartEnrollmentFor911.Pages.CrimeSurveys
{
    public class IndexModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        public IndexModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IList<CrimeSurvey> CrimeSurveys = new List<CrimeSurvey>();

        public async Task OnGetAsync()
        {
            string line;
            string path = Path.Combine(_environment.ContentRootPath, "CrimeSurveysStoreFile.txt");
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
                CrimeSurveys.Add(crimeSurvey);
            }
            file.Close();
        }
    }
}
