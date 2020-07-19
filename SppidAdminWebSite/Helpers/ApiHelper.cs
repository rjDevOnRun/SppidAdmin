using Newtonsoft.Json;
using SppidAdminGlobals;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace SppidAdminWebSite.Helpers
{
    public class ApiHelper
    {

        public static List<T> LoadDataFromAPI<T>(string apiAddress, 
            string apiActionName, string headerAcceptType)
        {
            // Init
            var _httpClient = new HttpClient();
            List<T> apiResultData = new List<T>();

            try
            {
                _httpClient.BaseAddress = new Uri(apiAddress);
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue(headerAcceptType));

                // Get API response
                HttpResponseMessage httpResponse = _httpClient.GetAsync(apiActionName).Result;
                if (httpResponse.IsSuccessStatusCode == false) return apiResultData;

                // Read response result as JSON
                var resultsFromAPI = httpResponse.Content.ReadAsStringAsync();

                // Convert JSON result to Collection <T>
                var resultToObjectCollection = JsonConvert.DeserializeObject<List<T>>(resultsFromAPI.Result);

                // Populate return collection
                apiResultData.AddRange(resultToObjectCollection);

                return apiResultData;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message + ex.StackTrace);
                return apiResultData;
            }
        }
    }
}