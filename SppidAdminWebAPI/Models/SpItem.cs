﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static SppidAdminGlobals.Enums;

namespace SppidAdminWebAPI.Models
{
    public class SpItem
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
    }
}