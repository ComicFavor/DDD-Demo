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
    public class AccountDomainService
    {
        private readonly AccountFactory _accountFactory;
        public AccountDomainService(AccountFactory accountFactory) 
        {
            _accountFactory = accountFactory;
        }
    }
}
