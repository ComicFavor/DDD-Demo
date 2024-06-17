using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.Core.Accounts.Command
{
    public class CreateAccountCommand
    {
        public string AccountName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
