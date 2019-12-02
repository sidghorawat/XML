using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartEnrollmentFor911.Models;

namespace SmartEnrollmentFor911.Pages.CrimeSurveys
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        public CreateModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CrimeSurvey CrimeSurvey { get; set; }
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string crimeSurvey = CrimeSurvey.FirstName + "," + CrimeSurvey.LastName + "," + CrimeSurvey.CityYouLive + "," + CrimeSurvey.isSafe + "," + CrimeSurvey.ShiftCity;
            string path = Path.Combine(_environment.ContentRootPath, "CrimeSurveysFile.txt");
            System.IO.File.AppendAllText(path, crimeSurvey + Environment.NewLine);
            return RedirectToPage("./Index");
        }
    }
}
