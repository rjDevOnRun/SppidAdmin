using Newtonsoft.Json;
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
    public class SpItemManagerViewModel
    {
        internal static async Task<List<PlantItem>> GetPlantItemsAsync()
        {
            List<PlantItem> projects = new List<PlantItem>();

            try
            {
                var webClient = new HttpClient();

                webClient.BaseAddress = new Uri(Constants.API_BaseAddress_SpItem);
                webClient.DefaultRequestHeaders.Clear();
                webClient.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage httpResponse = webClient.GetAsync("GetPipeRuns").Result;

                if (httpResponse.IsSuccessStatusCode == false) return projects;

                var jsonResultFromAPI = httpResponse.Content.ReadAsStringAsync();

                var jsonConvertedToObjects = JsonConvert.DeserializeObject<List<PlantItem>>
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