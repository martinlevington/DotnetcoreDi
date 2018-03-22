using DotnetcoreDiFactory.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetcoreDiFactory.Controllers
{
    public class SeefourController : Controller
    {
        public IFruit Fruit { get; }

        public SeefourController(IFruit fruit)
        {
            Fruit = fruit;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
