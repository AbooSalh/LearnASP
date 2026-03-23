using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{

    public class BankController : Controller
    {
        readonly int accountNumber = 123456789;
        readonly string accountHolderName = "John Doe";
        readonly int currentBalance = 1000;
        [Route("account-details")]
        public IActionResult AccountDetails()
        {
            return Json(new
            {
                AccountNumber = accountNumber,
                AccountHolderName = accountHolderName,
                CurrentBalance = currentBalance
            });
        }

        [Route("account-statement")]
        public IActionResult Details()
        {
            return File("statement.pdf", "application/pdf");
        }

        [Route("get-current-balance/{accountNumber}")]
        public IActionResult CurrentBalance(int accountNumber)
        {
            if (accountNumber == this.accountNumber)
            {
                return Json(new { CurrentBalance = currentBalance });
            }
            else
            {
                return NotFound("Account not found.");
            }
        }
    }
}
