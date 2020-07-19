using SppidAdminDTO.Models;
using SppidAdminWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static SppidAdminGlobals.Enums;

namespace SppidAdminWebAPI.Controllers
{
    public class SpItemController : ApiController
    {
        // GET: api/SpItem
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        /// <summary>
        /// Get Pipe Runs (limited by 100)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/SpItem/GetPipeRuns")]
        public List<PlantItem> GetPipeRuns()
        {
            List<PlantItem> plantItems = new List<PlantItem>();
            ItemType item = ItemType.PipeRun;

            plantItems = SpItemViewModel.GetPlantItems(item);

            return plantItems;

        }

        /// <summary>
        /// Get Plant Items by Type (limited by 100)
        /// </summary>
        /// <param name="plantItemType"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/SpItem/GetPlantItemsByType")]
        
        public List<PlantItem> GetPlantItemsByType(ItemType plantItemType)
        {
            List<PlantItem> plantItems = new List<PlantItem>();
            plantItems = SpItemViewModel.GetPlantItems(plantItemType);

            return plantItems;

        }

        // GET: api/SpItem/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SpItem
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SpItem/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SpItem/5
        public void Delete(int id)
        {
        }
    }
}
