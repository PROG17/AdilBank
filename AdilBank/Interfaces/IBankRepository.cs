using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdilBank.Models;

namespace AdilBank.Interfaces
{
    public interface IBankRepository
    {
        List<Customer> Customers { get; set; }
        List<Account> Accounts { get; set; }
        //void Transfer(double amount, Account fromAccount, Account targetAccount);
        //bool Withdraw(double amount, Account account);
        //void Deposit(double amount, Account account);
    }
}
