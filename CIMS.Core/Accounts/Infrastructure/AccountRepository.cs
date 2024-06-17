using CIMS.Core.Accounts.Domain;
using CIMS.Core.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.Core.Accounts.Infrastructure
{
    [RegisterService(ServiceLifetime.Scoped)]
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountContext _accountContext;
        public AccountRepository(AccountContext accountContext)
        {
            _accountContext = accountContext;
        }

        public Account ById(string id)
        {
            var account = _accountContext.Set<Account>().First(x => x.Id == id);
            if (account == null)
                throw new Exception($"Account {id} not found!");

            return account;
        }

        public void Delete(Account account)
        {
            _accountContext.Remove(account);
            _accountContext.SaveChanges();
        }

        public bool existByAccountName(string accountName)
        {
            var exists = _accountContext.Set<Account>().Count(x => x.AccountName == accountName) == 1;
            return exists;
        }

        public bool existByPhoneNumber(string phoneNumber)
        {
            var exists = _accountContext.Set<Account>().Where(x => x.PhoneNumber == phoneNumber).Count() == 1;
            return exists;
        }

        public void Save(Account account)
        {
            if (_accountContext.Entry(account).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                _accountContext.Add(account);
            }

            _accountContext.SaveChanges();
        }
    }
}
