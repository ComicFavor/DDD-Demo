using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.Core.Accounts.Domain
{
    public interface IAccountRepository
    {
        Account ById(string id);

        bool existByAccountName(string accountName);
        bool existByPhoneNumber(string phoneNumber);

        void Save(Account account);

        void Delete(Account account);
    }
}
