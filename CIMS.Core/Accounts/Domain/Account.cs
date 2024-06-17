using CIMS.Core.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.Core.Accounts.Domain
{
    public class Account: AggregateRoot
    {
        public string AccountName { get; private set; }
        public string PhoneNumber { get; private set; }
        public bool IsActive { get; private set; } = true;

        private Account(string accountName, string phoneNumber) 
        {
            this.AccountName = accountName;
            this.PhoneNumber = phoneNumber;
        }

        public void DeleteAccount()
        {
            this.IsActive = false;
            this.ModifiedTime = DateTime.Now;
            this.ModifiedBy = 1;
        }

        public void ActivateAccount()
        {
            this.IsActive = true;
            this.ModifiedTime = DateTime.Now;
            this.ModifiedBy = 1;
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public class Builder
        {
            private string _accountName = string.Empty;
            private string _phoneNumber = string.Empty;

            public Builder WithAccountName(string accountName)
            {
                _accountName = accountName;
                return this;
            }

            public Builder WithPhoneNumber(string phoneNumber)
            {
                _phoneNumber = phoneNumber;
                return this;
            }

            public Account Build()
            {
                return new Account(_accountName, _phoneNumber);
            }
        }
    }
}
