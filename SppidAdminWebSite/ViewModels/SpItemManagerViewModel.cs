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
    public class SpItemManagerViewModel
    {
        internal static async Task<List<PlantItem>> GetPlantItemsAsync()
        {
            List<PlantItem> plantItems = new List<PlantItem>();

            try
            {
                plantItems = ApiHelper.LoadDataFromAPI<PlantItem>
                               (Constants.API_BaseAddress_SpItem,
                               "GetPipeRuns", "application/json");

                return plantItems;

            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message + ex.StackTrace);
                return plantItems;
            }
        }
    }
}