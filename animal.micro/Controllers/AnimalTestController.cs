using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace animal.micro.Controllers
{
    public class AnimalTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}