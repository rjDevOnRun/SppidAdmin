using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SppidAdminGlobals;
using System.ComponentModel;
using static SppidAdminGlobals.Enums;

namespace SppidAdminDTO.Models
{
    public class Project
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Sppid Plant INI path")]
        public string IniPath { get; set; }

        [DisplayName("Database Type")]
        public DatabaseType DatabaseType { get; set; }

        [DisplayName("Database Name")]
        public string SiteDatabase { get; set; }

        [DisplayName("Plant Db (SqlServer)")]
        public string PlantDatabase { get; set; }

        [DisplayName("Db Port")]
        public int Port { get; set; } = 0;


    }
}