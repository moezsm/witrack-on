﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thermo.Models
{
    public class PostedFruits
    {
        //this array will be used to POST values from the form to the controller
        public string[] FruitIds { get; set; }
    }
}