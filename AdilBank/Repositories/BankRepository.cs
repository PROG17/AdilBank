using System.Collections.Generic;
using AdilBank.Interfaces;
using AdilBank.Models;

namespace AdilBank.Repositories
{
    public class BankRepository : IBankRepository
    {
        private const string Personkonto = "Personkonto";

        public BankRepository()
        {
            Customers.Add(new Customer {Id = 1, Name = "Adil" });
            Customers.Add(new Customer {Id = 2, Name = "Ahmad" });
            Customers.Add(new Customer {Id = 3, Name = "CustomerMed10kr" });

            Accounts.Add(new Account() { Name = Personkonto, Balance = 10000, Customer = Customers[0] });
            Accounts.Add(new Account() { Name = Personkonto, Balance = 10000000, Customer = Customers[1] });
            Accounts.Add(new Account() { Name = Personkonto, Balance = 10, Customer = Customers[2] });
        }

        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}