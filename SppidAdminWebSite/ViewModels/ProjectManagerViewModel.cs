using Newtonsoft.Json;
using SppidAdminDTO.Models;
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

        public static string API_Address_Build = "http://localhost:50534/api/Project/";

        public static async Task<List<Project>> GetAllProjectsAsync()
        {
            return await GetProjectFromAPI();
        }

        private async static Task<List<Project>> GetProjectFromAPI()
        {
            List<Project> projects = new List<Project>();

            try
            {
                /*  https://www.codeproject.com/Tips/996401/Authenticate-WebAPIs-with-Basic-and-Windows-Authen
                    https://www.c-sharpcorner.com/article/enable-windows-authentication-in-web-api-and-angular-app/ 
                    https://support.microsoft.com/en-us/help/323176/how-to-implement-windows-authentication-and-authorization-in-asp-net
                    https://stackoverflow.com/questions/24194941/windows-authentication-not-working-in-iis-express-debugging-with-visual-studio
                    https://www.youtube.com/watch?v=MeMUsUktf4E
                */

                //HttpClientHandler authtHandler = new HttpClientHandler()
                //{
                //    Credentials = CredentialCache.DefaultNetworkCredentials
                //};

                //var webClient = new HttpClient(authtHandler);
                var webClient = new HttpClient();

                webClient.BaseAddress = new Uri(API_Address_Build);
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