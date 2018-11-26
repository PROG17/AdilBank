using AdilBank.Models;
using AdilBank.Repositories;
using Xunit;

namespace AdilBankTest
{
    public class BankRepositoryTest
    {
        [Fact]
        public void Withdraw_method_should_withdraw_given_amount_from_account_balance()
        {
            var bankRepository = new BankRepository();
            var newCustomer = new Customer { Name = "Customer", Id = 11 };
            var newAccount = new Account { Name = "Account", Customer = newCustomer, Balance = 1000 };

            bankRepository.Accounts.Add(newAccount);

            var withdrawalSucceeded = bankRepository.Withdraw(200, newAccount.Name);

            Assert.True(withdrawalSucceeded);       
            Assert.Equal(800, newAccount.Balance);
        }

        [Fact]
        public void Withdraw_method_should_not_withdraw_if_withdrawal_amount_is_more_than_balance()
        {
            var bankRepository = new BankRepository();
            var newCustomer = new Customer { Name = "Customer", Id = 11 };
            var newAccount = new Account { Name = "Account", Customer = newCustomer, Balance = 1000 };

            bankRepository.Accounts.Add(newAccount);

            var withdrawalSucceeded = bankRepository.Withdraw(2000, newAccount.Name);

            Assert.False(withdrawalSucceeded);
            Assert.Equal(1000, newAccount.Balance);
        }

        [Fact]
        public void Deposit_method_should_deposit_given_amount_to_account_balance()
        {
            var bankRepository = new BankRepository();
            var newCustomer = new Customer { Name = "Customer", Id = 11 };
            var newAccount = new Account { Name = "Account", Customer = newCustomer, Balance = 1000 };

            bankRepository.Accounts.Add(newAccount);

            bankRepository.Deposit(10, newAccount.Name);

            Assert.Equal(1010, newAccount.Balance);
        }
    }
}