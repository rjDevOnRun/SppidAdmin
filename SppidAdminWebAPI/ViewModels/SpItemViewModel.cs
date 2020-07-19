using SppidAdminDTO.Models;
using SppidAdminWebAPI.DataRepository;
using SppidAdminWebAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using static SppidAdminGlobals.Enums;

namespace SppidAdminWebAPI.ViewModels
{
    public class SpItemViewModel
    {

        public static List<PlantItem> GetPlantItems(ItemType plantItemType)
        {
            

            DataTable dtPlantItems = SpItemRepository.GetPlantItemsFromDatabase(plantItemType);

            List<PlantItem> plantItems = new List<PlantItem>();

            plantItems = AssemblyHelpers.ConvertDataTable<PlantItem>(dtPlantItems);

            return plantItems;
        }

    }
}