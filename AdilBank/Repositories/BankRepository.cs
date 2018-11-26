using AdilBank.Models;
using System.Collections.Generic;
using System.Linq;

namespace AdilBank.Repositories
{
    public class BankRepository
    {
        public List<Customer> Customers { get; set; }
        public List<Account> Accounts { get; set; }

        public BankRepository()
        {
            Customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "Adil"},
                new Customer {Id = 2, Name = "Ahmad"},
                new Customer {Id = 3, Name = "CustomerMed10kr"}
            };

            Accounts = new List<Account>
            {
                new Account() {Name = "01234", Balance = 10000, Customer = Customers[0]},
                new Account() {Name = "56789", Balance = 10000000, Customer = Customers[1]},
                new Account() {Name = "00000", Balance = 10, Customer = Customers[2]}
            };
        }

        public void Transfer(double amount, string fromAccount, string targetAccount)
        {
            var withdrawalSucceeded = Withdraw(amount, fromAccount);

            if (withdrawalSucceeded) Deposit(amount, targetAccount);
        }

        public bool Withdraw(double amount, string accountName)
        {
            var withdrawalAccount = Accounts.FirstOrDefault(account => account.Name == accountName);
            if (withdrawalAccount == null || withdrawalAccount.Balance < amount) return false;
            withdrawalAccount.Balance -= amount;
            return true;
        }

        public void Deposit(double amount, string accountName)
        {
            var depositAccount = Accounts.FirstOrDefault(account => account.Name == accountName);

            if (depositAccount != null) depositAccount.Balance += amount;
        }
    }
}