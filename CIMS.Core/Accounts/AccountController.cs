using CIMS.Core.Accounts.Command;
using CIMS.Core.Accounts.Domain;
using CIMS.Core.Accounts.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CIMS.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountCommandService _accountCommandService;
        public AccountController(AccountCommandService accountCommandService) { 
            _accountCommandService = accountCommandService;
        }

        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return new AccountQueryService().All();
        }

        [HttpPost]
        public IActionResult Create(CreateAccountCommand command)
        {
            _accountCommandService.CreateAccount(command);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(DeleteAccountCommand command)
        {
            _accountCommandService.DeleteAccount(command);
            return Ok();
        }

        [HttpPost("activate")]
        public IActionResult Activate(ActivateAccountCommand command)
        {
            _accountCommandService.ActivateAccount(command);
            return Ok();
        }
    }
}
