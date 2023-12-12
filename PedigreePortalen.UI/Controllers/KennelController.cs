using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PedigreePortalen.UI.Controllers
{
    public class KennelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}