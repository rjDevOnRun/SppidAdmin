using Newtonsoft.Json;
using SppidAdminDTO.Models;
using SppidAdminGlobals;
using SppidAdminWebSite.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace SppidAdminWebSite.ViewModels
{
    public class ProjectManagerViewModel
    {
        public static async Task<List<Project>> GetAllProjectsAsync()
        {
            return await GetProjectFromAPI();
        }

        private async static Task<List<Project>> GetProjectFromAPI()
        {
            List<Project> projects = new List<Project>();

            try
            {
                projects = ApiHelper.LoadDataFromAPI<Project>
                            (Constants.API_BaseAddress_Project, 
                            "AllProjects", "application/json");

                return projects;

            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message + ex.StackTrace);
                return projects;
            }
        }
    }
}