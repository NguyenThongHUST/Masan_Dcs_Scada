using Masan_Dcs_Scada.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Masan_Dcs_Scada.Controllers
{
    public class StockController : Controller
    {
        DatabaseContext _db;

        public StockController(DatabaseContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            TempData["products"] = Newtonsoft.Json.JsonConvert.SerializeObject(_db.Products.ToList());
            return View();
        }
    }
}
