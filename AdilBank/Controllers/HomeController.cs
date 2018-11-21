using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AdilBank.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AdilBank.Models;
using AdilBank.Repositories;

namespace AdilBank.Controllers
{
    public class HomeController : Controller
    {
        private IBankRepository _bankRepository;

        public IActionResult Index()
        {
            _bankRepository = new BankRepository();
            return View(_bankRepository);
        }  

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}