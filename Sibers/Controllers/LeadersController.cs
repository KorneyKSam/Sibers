﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibers.Controllers
{
    public class LeadersController : Controller
    {
        public IActionResult Table()
        {
            return View();
        }
    }
}
