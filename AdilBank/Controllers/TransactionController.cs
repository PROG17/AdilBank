using AdilBank.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AdilBank.Controllers
{
    public class TransactionController : Controller
    {
        private readonly BankRepository _bankRepository;

        public TransactionController(BankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public IActionResult Index()
        {
            return View(_bankRepository);
        }

        [HttpPost]
        public IActionResult Index(string transactionType, double accountBalance, double amount, string accountName)
        {
            double sum; 

            if (transactionType == "Uttag")
            {
                if (amount > accountBalance)
                {
                    ViewBag.Message = "Värdet är för högt!";
                    return View(_bankRepository);
                }
                _bankRepository.Withdraw(amount, accountName);
                sum = accountBalance - amount;
                ViewBag.Message = $"Det har dragits {amount} från kontot {accountName}, saldo är nu {sum}";
                return View(_bankRepository);
            }

            _bankRepository.Deposit(amount, accountName);
            sum = accountBalance + amount;
            ViewBag.Message = $"Det har lagts till {amount} till kontot {accountName}, saldo är nu {sum}";
            return View(_bankRepository);
        }
    }
}