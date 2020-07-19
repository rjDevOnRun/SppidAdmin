using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SppidAdminGlobals.Enums;

namespace SppidAdminDTO.Models
{
    public class PlantItem
    {
        [DisplayName("SP ID")]
        public string SP_ID { get; set; }

        [DisplayName("SP Item Name")]
        public string NAME { get; set; }

        [DisplayName("Item Tag")]
        public string ITEMTAG { get; set; }

        [DisplayName("Plant Item Type")]
        public ItemType PLANTITEMTYPE { get; set; }


    }
}
