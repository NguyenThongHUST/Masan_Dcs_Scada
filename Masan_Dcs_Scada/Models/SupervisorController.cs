using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Masan_Dcs_Scada.Models
{
    public class SupervisorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
