using CIMS.Core.Accounts.Domain;
using CIMS.Core.Accounts.Infrastructure;
using CIMS.Core.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.Core.Accounts.Command
{
    [RegisterService(ServiceLifetime.Scoped)]
    public class AccountCommandService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly AccountFactory _accountFactory;
        public AccountCommandService(AccountFactory accountFactory, IAccountRepository accountRepository) 
        {
            _accountFactory = accountFactory;
            _accountRepository = accountRepository;
        }

        public void CreateAccount(CreateAccountCommand command)
        {
            // [Factory] Create a new account
            var account = _accountFactory.Create(
                command.AccountName, 
                command.PhoneNumber);

            // [Repository] Save to db
            _accountRepository.Save(account);

            // log
            Debug.WriteLine($"Account {command.AccountName} was created successfully!");
        }

        public void DeleteAccount(DeleteAccountCommand command)
        {
            // [Repository] get an account
            var account = _accountRepository.ById(command.Id);

            // [Domain Object]
            account.DeleteAccount();

            // [Repository] Save to db
            _accountRepository.Save(account);

            // log
            Debug.WriteLine($"Account {command.Id} was deleted successfully!");
        }

        public void ActivateAccount(ActivateAccountCommand command)
        {
            // [Repository] get an account
            var account = _accountRepository.ById(command.Id);

            // [Domain Object]
            account.ActivateAccount();

            // [Repository] Save to db
            _accountRepository.Save(account);

            // log
            Debug.WriteLine($"Account {command.Id} was activated successfully!");
        }
    }
}
