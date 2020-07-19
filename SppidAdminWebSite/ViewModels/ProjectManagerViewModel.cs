﻿using Newtonsoft.Json;
using SppidAdminDTO.Models;
using SppidAdminGlobals;
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
                var webClient = new HttpClient();

                webClient.BaseAddress = new Uri(Constants.API_BaseAddress_Project);
                webClient.DefaultRequestHeaders.Clear();
                webClient.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage httpResponse = webClient.GetAsync("AllProjects").Result;

                if (httpResponse.IsSuccessStatusCode == false) return projects;

                var jsonResultFromAPI = httpResponse.Content.ReadAsStringAsync();

                var jsonConvertedToObjects = JsonConvert.DeserializeObject<List<Project>>
                                                            (jsonResultFromAPI.Result);
                projects.AddRange(jsonConvertedToObjects);

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