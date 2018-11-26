using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdilBank.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AdilBank.Controllers
{
    public class TransferController : Controller
    {
        private readonly BankRepository _bankRepository;

        public TransferController(BankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public IActionResult Index()
        {
            return View(_bankRepository);
        }

        [HttpPost]
        public IActionResult Index(string transactionType, double amount, string fromAccount, string targetAccount)
        {
            var withdrawalAccount = _bankRepository.Accounts.FirstOrDefault(account => account.Name == fromAccount);

            if (withdrawalAccount != null)
            {
                var result = _bankRepository.Transfer(amount, fromAccount, targetAccount);
                if (result == false)
                {
                    ViewBag.Message = $"Konto {fromAccount} har inte tillräckligt med pengar";
                    return View(_bankRepository);
                }
                else
                {
                    ViewBag.Message = $"{amount} har överförts från {fromAccount} till {targetAccount}";
                    return View(_bankRepository);
                }
            }
            else
            {
                ViewBag.Message = $"Kontot finns ej";
                return View(_bankRepository);
            }
        }
    }
}