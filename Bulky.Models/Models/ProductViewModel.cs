﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bulky.Models.Models
{
    public class ProductViewModel
    {
        public Products product { get; set; }
       public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
