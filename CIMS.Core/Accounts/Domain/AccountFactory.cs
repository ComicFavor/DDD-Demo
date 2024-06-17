using CIMS.Core.Accounts.Infrastructure;
using CIMS.Core.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.Core.Accounts.Domain
{
    [RegisterService(ServiceLifetime.Scoped)]
    public class AccountFactory
    {
        private readonly IAccountRepository _accountRepository;
        public AccountFactory(IAccountRepository accountRepository) 
        {
            _accountRepository = accountRepository;
        }
        public Account Create(string accountName, string phoneNumber)
        {
            // [Repository] Checking
            if (_accountRepository.existByAccountName(accountName) == true)
            {
                throw new Exception($"Same account name {accountName} already exists!");
            }

            if (_accountRepository.existByPhoneNumber(phoneNumber) == true)
            {
                throw new Exception($"Same phone number {phoneNumber} already exists!");
            }

            // [Domain Object]
            return Account.CreateBuilder()
                .WithAccountName(accountName)
                .WithPhoneNumber(phoneNumber)
                .Build();
        }
    }
}
