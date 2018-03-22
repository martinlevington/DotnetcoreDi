using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DotnetcoreDiFactory.Domain;
using Microsoft.AspNetCore.Mvc;
using DotnetcoreDiFactory.Models;

namespace DotnetcoreDiFactory.Controllers
{
    public class HomeController : Controller
    {
        public IFruit Apple { get; }

        public HomeController(IFruit apple)
        {
            Apple = apple;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
