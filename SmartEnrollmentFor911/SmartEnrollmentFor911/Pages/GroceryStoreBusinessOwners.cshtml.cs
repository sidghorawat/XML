using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreBusinessOwners;

namespace SmartEnrollmentFor911.Pages
{
    public class GroceryStoreBusinessOwnersModel : PageModel
    {
        public void OnGet()
        {
            String businessOwnerJson = GetData("https://grocerystores.azurewebsites.net/api/BusinessOwnerAPIServices");
            var businessOwners = GroceryStoreBusinessOwnerAPI.FromJson(businessOwnerJson);
            ViewData["BusinessOwners"] = businessOwners;
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