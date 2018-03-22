using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetcoreDi.Repositories;
using DotnetcoreDi.Services;
using Microsoft.AspNetCore.Mvc;
using Autofac.Features.AttributeFilters;

namespace DotnetcoreDi.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IServiceOne _serviceOne;
        private readonly IRepositoryX _repositoryX;

        public QuestionController(IServiceOne serviceOne, [KeyFilter("secondX")] IRepositoryX repositoryX)
        {
            _serviceOne = serviceOne;
            _repositoryX = repositoryX;
        }

       

        public IActionResult Index()
        {
            return View();
        }
    }
}