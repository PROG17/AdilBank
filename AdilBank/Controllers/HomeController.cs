using AdilBank.Models;
using AdilBank.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdilBank.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankRepository _bankRepository;

        public HomeController(BankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public IActionResult Index()
        {
            return View(_bankRepository);
        }  

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}